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
using WHS.Core.Session;

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
                string countSql = $"select count(mo) {baseSql} where @Mo is null or mo like @Mo and factory_id = @FactoryID;";
                string dataSql = $@"select mo, style, color, type_detail, supplier, quantity_to_received, received_quantity, expected_quantity {baseSql}
                                    where @Mo is null or mo like @Mo and factory_id = @FactoryID
                                    order by modified_at
                                    offset @Offset rows fetch next @PageSize rows only;";

                // Tạo paramers
                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                var parameters = new
                {
                    Offset = offset,
                    paginate.PageSize,
                    Mo = string.IsNullOrEmpty(receiveSearch.MO) ? null : $"%{receiveSearch.MO}%",
                    Session.CurrentUser.FactoryID
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
        /// Get dữ liệu chi tiết
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<PageDto<FabricReceivedDto>>> GetDetailReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string baseSql = "from vw_npl_fabric_detail";
                string whereClause = @"where (@Mo is null or mo like @Mo) and
                                             (@Status is null or status = @Status) and
                                             (@DispatchStatus is null or dispatch_status = @DispatchStatus)
                                              and factory_id = @FactoryID";
                string countSql = $"select count(id) {baseSql} {whereClause};";
                string dataSql = $@"select * {baseSql}
                                    {whereClause}
                                    order by id desc
                                    offset @Offset rows fetch next @PageSize rows only;";

                // Tạo paramers
                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                var parameters = new
                {
                    Offset = offset,
                    paginate.PageSize,
                    Mo = string.IsNullOrEmpty(receiveSearch.MO) ? null : $"%{receiveSearch.MO}%",
                    Status = receiveSearch.Status == -1 ? null : receiveSearch.Status,
                    DispatchStatus = receiveSearch.DispatchStatus == -1 ? null : receiveSearch.DispatchStatus,
                    Session.CurrentUser.FactoryID
                };

                // Lấy số lượng bản ghi và dữ liệu
                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<FabricReceivedDto> items = (await conn.QueryAsync<FabricReceivedDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<FabricReceivedDto> result = new PageDto<FabricReceivedDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<FabricReceivedDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<FabricReceivedDto>>.Show(ex);
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
                        isnull(r.fabric_number, ''),
                        isnull(r.factory_id, '')
                    ))
                ";

            return await CheckDuplicateBase(detail, columnChecks, sqlCheck);
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
                if (!detail.Columns.Contains("FactoryID"))
                    detail.Columns.Add("FactoryID", typeof(int));

                foreach (DataRow row in detail.Rows)
                {
                    row["CreatedBy"] = Session.CurrentUser.Code;
                    row["ModifiedBy"] = Session.CurrentUser.Code;
                    row["FactoryID"] = Session.CurrentUser.FactoryID;
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
                    bulkCopy.ColumnMappings.Add("FactoryID", "factory_id");

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
                where (@MO is null or mo = @MO) and 
                    (@Style is null or style = @Style) and 
                    (@Color is null or color = @Color) and 
                    (@TypeDetail is null or fabric_type = @TypeDetail) and 
                    (@Supplier is null or supplier = @Supplier) and
                    factory_id = @FactoryID";

                var parameters = new
                {
                    receiveData.MO,
                    receiveData.Style,
                    receiveData.Color,
                    receiveData.TypeDetail,
                    receiveData.Supplier,
                    Session.CurrentUser.FactoryID
                };

                var result = (await conn.QueryAsync<FabricReceivedDto>(sql, parameters)).ToList();
                return Response<List<FabricReceivedDto>>.Success(result);
            }
            catch (Exception ex) 
            { 
                return ErrorHandler<List<FabricReceivedDto>>.Show(ex);  
            }
        }

        /// <summary>
        /// Lấy ra danh sách dữ liệu chưa điều phối
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async override Task<Response<List<FabricDto>>> GetListReceiveAsync()
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select id, mo, supplier, style, color, fabric_type, batch, 
                    fabric_length, length_unit, fabric_weight, weight_unit, roll_width, width_unit, fabric_number, quantity_to_received, quantity_unit,
                    order_date, available_date, expected_date, is_cancelled
                from vw_npl_fabric_detail
                where status = 0 or status = 3 and factory_id = @FactoryID";

                var result = (await conn.QueryAsync<FabricDto>(sql, new {Session.CurrentUser.FactoryID})).ToList();
                return Response<List<FabricDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<FabricDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Check xem có dữ liệu nào đã điều phối chưa
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<bool>> CheckHasDispatch(List<int> ids)
        {
            return await CheckHasDispatchBase(ids, "vw_npl_fabric_detail");
        }

        /// <summary>
        /// Update chi tiết npl chưa điều phối
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<int>> UpdateReceivedDetail(List<FabricDto> data)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                var table = new DataTable();

                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("MO", typeof(string));
                table.Columns.Add("Supplier", typeof(string));
                table.Columns.Add("Style", typeof(string));
                table.Columns.Add("Color", typeof(string));
                table.Columns.Add("FabricType", typeof(string));
                table.Columns.Add("Batch", typeof(string));
                table.Columns.Add("FabricLength", typeof(float));
                table.Columns.Add("LengthUnit", typeof(string));
                table.Columns.Add("FabricWeight", typeof(float));
                table.Columns.Add("WeightUnit", typeof(string));
                table.Columns.Add("RollWidth", typeof(float));
                table.Columns.Add("WidthUnit", typeof(string));
                table.Columns.Add("FabricNumber", typeof(int));
                table.Columns.Add("QuantityToReceived", typeof(int));
                table.Columns.Add("QuantityUnit", typeof(string));
                table.Columns.Add("OrderDate", typeof(DateTime));
                table.Columns.Add("AvailableDate", typeof(DateTime));
                table.Columns.Add("ExpectedDate", typeof(DateTime));
                table.Columns.Add("IsCancelled", typeof(bool));

                foreach (var item in data)
                {
                    table.Rows.Add(
                        item.ID,
                        item.MO,
                        item.Supplier,
                        item.Style,
                        item.Color,
                        item.FabricType,
                        item.Batch,
                        item.FabricLength,
                        item.LengthUnit,
                        item.FabricWeight,
                        item.WeightUnit,
                        item.RollWidth,
                        item.WidthUnit,
                        item.FabricNumber,
                        item.QuantityToReceived,
                        item.QuantityUnit,
                        item.OrderDate ?? (object)DBNull.Value,
                        item.AvailableDate ?? (object)DBNull.Value,
                        item.ExpectedDate ?? (object)DBNull.Value,
                        item.IsCancelled ?? (object)DBNull.Value
                    );
                }

                using (var cmd = new SqlCommand("viet_sp_update_fabric_received", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var param = cmd.Parameters.AddWithValue("@FabricDetails", table);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.NplFabricDetailType";

                    cmd.Parameters.AddWithValue("@ModifiedBy", Session.CurrentUser.Code);

                    var rows = await cmd.ExecuteNonQueryAsync();

                    return Response<int>.Success(rows, "Cập nhật vải thành công");
                }
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }
    }
}
