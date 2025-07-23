using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;

namespace WHS.Repository.Repository.Receive
{
    public class PlspReceiveRepository : ReceiveRepository<PlspDto, PlspReceivedDto>
    {
        public PlspReceiveRepository(IConfiguration configuration) : base(configuration)
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
                string baseSql = "from vw_grouped_plsp_received";
                string countSql = $"select count(mo) {baseSql} where  @Mo is null or mo like @Mo;";
                string dataSql = $@"select mo, type_detail, supplier, quantity_to_received, received_quantity, expected_quantity {baseSql}
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
        /// Check duplicate value
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public override async Task<Response<bool>> CheckDuplicateValue(DataTable detail)
        {
            var columnChecks = new List<string>
            {
                "MO", "Supplier", "PlspType", "PlspCode", "MarketCode", "NplColor", "Size", "PlspColor"
            };

            string sqlCheck = @"
                select distinct t.keyhash
                from #tempkeys t
                join sys_npl_plsp_received r on
                    t.keyhash collate sql_latin1_general_cp1_ci_as = lower(concat_ws('||',
                        isnull(r.mo, ''),
                        isnull(r.supplier, ''),
                        isnull(r.plsp_type, ''),
                        isnull(r.plsp_code, ''),
                        isnull(r.market_code, ''),
                        isnull(r.npl_color, ''),
                        isnull(r.size, ''),
                        isnull(r.plsp_color, '')
                    ))
                ";

            return await BaseCheckDuplicate(detail, columnChecks, sqlCheck);
        }

        public override async Task<Response<int>> CreateReceiveAsync(DataTable detail)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var transaction = conn.BeginTransaction();

            try
            {
                // Thêm created_by vào Datatable
                if (!detail.Columns.Contains("CreatedBy"))
                    detail.Columns.Add("CreatedBy", typeof(int));

                // Thêm modified_by vào Datatable
                if (!detail.Columns.Contains("ModifiedBy"))
                    detail.Columns.Add("ModifiedBy", typeof(int));

                foreach (DataRow row in detail.Rows)
                {
                    row["CreatedBy"] = 0;
                    row["ModifiedBy"] = 0;
                }

                // Bước3: Insert bảng con bằng SqlBulkCopy
                using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                {
                    bulkCopy.DestinationTableName = "sys_npl_plsp_received";

                    // Ánh xạ cột
                    bulkCopy.ColumnMappings.Add("MO", "mo");
                    bulkCopy.ColumnMappings.Add("Supplier", "supplier");
                    bulkCopy.ColumnMappings.Add("PlspType", "plsp_type");
                    bulkCopy.ColumnMappings.Add("PlspCode", "plsp_code");
                    bulkCopy.ColumnMappings.Add("NplColor", "npl_color");
                    bulkCopy.ColumnMappings.Add("MarketCode", "market_code");
                    bulkCopy.ColumnMappings.Add("Size", "size");
                    bulkCopy.ColumnMappings.Add("PlspColor", "plsp_color");
                    bulkCopy.ColumnMappings.Add("QuantityToReceived", "quantity_to_received");
                    bulkCopy.ColumnMappings.Add("OrderDate", "order_date");
                    bulkCopy.ColumnMappings.Add("AvailableDate", "available_date");
                    bulkCopy.ColumnMappings.Add("ExpectedDate", "expected_date");
                    bulkCopy.ColumnMappings.Add("CreatedBy", "created_by");
                    bulkCopy.ColumnMappings.Add("ModifiedBy", "modified_by");

                    await bulkCopy.WriteToServerAsync(detail);
                }

                // Commit
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
            //    type_detail = @TypeDetail,
            //    supplier = @Supplier,
            //    quantity_to_received = @QuantityToReceived,
            //    quantity_estimate = @QuantityEstimate,
            //    modified_by = @ModifiedBy,
            //    modified_at = GETDATE()
            //where id = @ID;";

            //var parentParams = new
            //{
            //    plsp.MO,
            //    plsp.TypeDetail,
            //    plsp.Supplier,
            //    plsp.QuantityToReceived,
            //    plsp.QuantityEstimate,
            //    ModifiedBy = 0,
            //    ID = id,
            //};

            //return await UpdateReceiveBaseAsync(id, updateSql, parentParams, detail,
            //    "viet_sp_upsert_npl_plsp_detail", "dbo.NplPlspDetailType");

            return Response<int>.Success(1);
        }

        /// <summary>
        /// Lấy ra detail chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<List<PlspReceivedDto>>> GetReceiveDetailAsync(GroupReceiveDto receiveData)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select *
                from vw_npl_plsp_detail
                where mo = @MO and plsp_type = @TypeDetail and supplier = @Supplier";

                var parameters = new
                {
                    receiveData.MO,
                    receiveData.TypeDetail,
                    receiveData.Supplier
                };

                var result = (await conn.QueryAsync<PlspReceivedDto>(sql, parameters)).ToList();
                return Response<List<PlspReceivedDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PlspReceivedDto>>.Show(ex);
            }
        }
    }
}
