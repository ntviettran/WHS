using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WHS.Core.Dto;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;

namespace WHS.Repository.Repository.Receive
{
    public class FabricReceiveRepository: ReceiveRepository<FabricDto, FabricReceivedDto>
    {
        public FabricReceiveRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Get dữ liệu grouped theo mo
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<PageDto<GroupReceiveDto>>> GetGroupedReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string baseSql = "from vw_grouped_fabric_received";
                string countSql = $"select count(mo) {baseSql} where  @Mo is null or mo like @Mo;";
                string dataSql = $@"select mo, style, color, type_detail, supplier, quantity_to_received, received_quantity, expected_quantity {baseSql}
                                    where @Mo is null or mo like @Mo
                                    order by modified_at
                                    offset @Offset rows fetch next @PageSize rows only;";

                // Tạo paramers
                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                var parameters = new
                {
                    Offset = offset,
                    paginate.PageSize,
                    Mo = string.IsNullOrEmpty(receiveSearch.MO) ? null : $"%{receiveSearch.MO}%"
                };

                // Lấy số lượng bản ghi và dữ liệu
                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<GroupReceiveDto> items = (await conn.QueryAsync<GroupReceiveDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<GroupReceiveDto> result = new PageDto<GroupReceiveDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<GroupReceiveDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<GroupReceiveDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Check xem có trùng dữ liệu
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public override async Task<Response<bool>> CheckDuplicateValue(DataTable detail)
        {
            var columnChecks = new List<string>
            {
                "MO", "Supplier", "Style", "Color", "FabricType", "Batch", "FabricNumber"
            };

            string sqlCheck = @"
                select distinct t.keyhash
                from #tempkeys t
                join sys_npl_fabric_received r on
                    t.keyhash collate sql_latin1_general_cp1_ci_as = lower(concat_ws('||',
                        isnull(r.mo, ''),
                        isnull(r.supplier, ''),
                        isnull(r.style, ''),
                        isnull(r.color, ''),
                        isnull(r.fabric_type, ''),
                        isnull(r.batch, ''),
                        isnull(r.fabric_number, '')
                    ))
                ";

            return await BaseCheckDuplicate(detail, columnChecks, sqlCheck);
        }

        /// <summary>
        /// Thêm mới dữ liệu npl vải
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public override async Task<Response<int>> CreateReceiveAsync(DataTable detail)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var transaction = conn.BeginTransaction();

            try
            {

                // Thêm CreatedBy / ModifiedBy nếu chưa có
                if (!detail.Columns.Contains("CreatedBy"))
                    detail.Columns.Add("CreatedBy", typeof(int));
                if (!detail.Columns.Contains("ModifiedBy"))
                    detail.Columns.Add("ModifiedBy", typeof(int));

                foreach (DataRow row in detail.Rows)
                {
                    row["CreatedBy"] = 0;
                    row["ModifiedBy"] = 0;
                }

                // Xóa cột KeyHash trước khi insert nếu không có trong bảng thật
                detail.Columns.Remove("KeyHash");

                // Insert bằng SqlBulkCopy
                using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                {
                    bulkCopy.DestinationTableName = "sys_npl_fabric_received";

                    bulkCopy.ColumnMappings.Add("MO", "mo");
                    bulkCopy.ColumnMappings.Add("Supplier", "supplier");
                    bulkCopy.ColumnMappings.Add("Style", "style");
                    bulkCopy.ColumnMappings.Add("Color", "color");
                    bulkCopy.ColumnMappings.Add("FabricType", "fabric_type");
                    bulkCopy.ColumnMappings.Add("Batch", "batch");
                    bulkCopy.ColumnMappings.Add("FabricLength", "fabric_length");
                    bulkCopy.ColumnMappings.Add("LengthUnit", "length_unit");
                    bulkCopy.ColumnMappings.Add("FabricWeight", "fabric_weight");
                    bulkCopy.ColumnMappings.Add("WeightUnit", "weight_unit");
                    bulkCopy.ColumnMappings.Add("RollWidth", "roll_width");
                    bulkCopy.ColumnMappings.Add("WidthUnit", "width_unit");
                    bulkCopy.ColumnMappings.Add("FabricNumber", "fabric_number");
                    bulkCopy.ColumnMappings.Add("QuantityToReceived", "quantity_to_received");
                    bulkCopy.ColumnMappings.Add("QuantityUnit", "quantity_unit");
                    bulkCopy.ColumnMappings.Add("OrderDate", "order_date");
                    bulkCopy.ColumnMappings.Add("AvailableDate", "available_date");
                    bulkCopy.ColumnMappings.Add("ExpectedDate", "expected_date");
                    bulkCopy.ColumnMappings.Add("CreatedBy", "created_by");
                    bulkCopy.ColumnMappings.Add("ModifiedBy", "modified_by");

                    await bulkCopy.WriteToServerAsync(detail);
                }

                transaction.Commit();
                return Response<int>.Success(1, "Đã tạo NPL thành công!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Chỉnh sửa NPL vải
        /// </summary>
        /// <param name="data"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<int>> UpdateReceiveAsync(int id, DataTable detail)
        {
            //string updateSql = @"
            //update npl_received
            //set
            //    mo = @Mo,
            //    style = @Style,
            //    color = @Color,
            //    type_detail = @FabricType,
            //    supplier = @Supplier,
            //    quantity_to_received = @QuantityToReceived,
            //    quantity_estimate = @QuantityEstimate,
            //    modified_by = @ModifiedBy,
            //    modified_at = GETDATE()
            //where id = @ID;";

            //var parentParams = new
            //{
            //    fabric.MO,
            //    fabric.Style,
            //    fabric.Color,
            //    fabric.FabricType,
            //    fabric.Supplier,
            //    fabric.QuantityToReceived,
            //    fabric.QuantityEstimate,
            //    ModifiedBy = 0,
            //    ID = id,
            //};

            //return await UpdateReceiveBaseAsync(id, updateSql, parentParams, detail,
            //    "viet_sp_upsert_npl_fabric_detail", "dbo.NplFabricDetailType");

            return Response<int>.Success(1);
        }

        /// <summary>
        /// Lấy ra detail chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Response<List<FabricReceivedDto>>> GetReceiveDetailAsync(GroupReceiveDto receiveData)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select *
                from vw_npl_fabric_detail
                where mo = @MO and style = @Style and color = @Color and fabric_type = @TypeDetail and supplier = @Supplier";

                var parameters = new
                {
                    receiveData.MO,
                    receiveData.Style,
                    receiveData.Color,
                    receiveData.TypeDetail,
                    receiveData.Supplier
                };

                var result = (await conn.QueryAsync<FabricReceivedDto>(sql, parameters)).ToList();
                return Response<List<FabricReceivedDto>>.Success(result);
            }
            catch (Exception ex) 
            { 
                return ErrorHandler<List<FabricReceivedDto>>.Show(ex);  
            }
        }
    }
}
