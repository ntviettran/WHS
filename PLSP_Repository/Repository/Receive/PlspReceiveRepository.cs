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
using WHS.Core.Session;

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
                string countSql = $"select count(mo) {baseSql} where (@Mo is null or mo like @Mo) and factory_id = @FactoryID;";
                string dataSql = $@"select mo, type_detail, supplier, quantity_to_received, received_quantity, expected_quantity {baseSql}
                                    where (@Mo is null or mo like @Mo) and factory_id = @FactoryID
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
        public override async Task<Response<PageDto<PlspReceivedDto>>> GetDetailReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string baseSql = "from vw_npl_plsp_detail";
                string whereClause = @"where (@Mo is null or mo like @Mo) and
                                             (@Status is null or status = @Status) and
                                             (@DispatchStatus is null or dispatch_status = @DispatchStatus) and
                                             factory_id = @FactoryID";
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
                List<PlspReceivedDto> items = (await conn.QueryAsync<PlspReceivedDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<PlspReceivedDto> result = new PageDto<PlspReceivedDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<PlspReceivedDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<PlspReceivedDto>>.Show(ex);
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
                        isnull(r.plsp_color, ''),
                        isnull(r.factory_id, '')
                    ))
                ";

            return await CheckDuplicateBase(detail, columnChecks, sqlCheck);
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

                if (!detail.Columns.Contains("FactoryID"))
                    detail.Columns.Add("FactoryID", typeof(int));

                foreach (DataRow row in detail.Rows)
                {
                    row["CreatedBy"] = Session.CurrentUser.Code;
                    row["ModifiedBy"] = Session.CurrentUser.Code;
                    row["FactoryID"] = Session.CurrentUser.FactoryID;
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
                    bulkCopy.ColumnMappings.Add("FactoryID", "factory_id");

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
                string sql = @"select * from vw_npl_plsp_detail
                where (@MO is null or mo = @MO)
                and (@TypeDetail is null or plsp_type = @TypeDetail)
                and (@Supplier is null or supplier = @Supplier)
                and factory_id = @FactoryID";

                var parameters = new
                {
                    receiveData.MO,
                    receiveData.TypeDetail,
                    receiveData.Supplier,
                    Session.CurrentUser.FactoryID
                };

                var result = (await conn.QueryAsync<PlspReceivedDto>(sql, parameters)).ToList();
                return Response<List<PlspReceivedDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PlspReceivedDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách dữ liệu chưa điều phối
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async override Task<Response<List<PlspDto>>> GetListReceiveAsync()
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select id, mo, supplier, plsp_type, plsp_code, npl_color, market_code, 
                    size, plsp_color, quantity_to_received, order_date, available_date, expected_date, is_cancelled
                from vw_npl_plsp_detail
                where status = 0 or status = 3 and factory_id = @FactoryID";

                var result = (await conn.QueryAsync<PlspDto>(sql, new {Session.CurrentUser.FactoryID})).ToList();
                return Response<List<PlspDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PlspDto>>.Show(ex);
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
            return await CheckHasDispatchBase(ids, "vw_npl_plsp_detail");
        }

        /// <summary>
        /// Update chi tiết npl chưa điều phối
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<int>> UpdateReceivedDetail(List<PlspDto> data)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                var table = new DataTable();

                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("MO", typeof(string));
                table.Columns.Add("Supplier", typeof(string));
                table.Columns.Add("PlspType", typeof(string));
                table.Columns.Add("PlspCode", typeof(string));
                table.Columns.Add("NplColor", typeof(string));
                table.Columns.Add("MarketCode", typeof(string));
                table.Columns.Add("Size", typeof(string));
                table.Columns.Add("PlspColor", typeof(string));
                table.Columns.Add("QuantityToReceived", typeof(int));
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
                        item.PlspType,
                        item.PlspCode,
                        item.NplColor,
                        item.MarketCode,
                        item.Size,
                        item.PlspColor,
                        item.QuantityToReceived,
                        item.OrderDate ?? (object)DBNull.Value,
                        item.AvailableDate ?? (object)DBNull.Value,
                        item.ExpectedDate ?? (object)DBNull.Value,
                        item.IsCancelled ?? (object)DBNull.Value
                    );
                }

                using (var cmd = new SqlCommand("viet_sp_update_plsp_received", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var param = cmd.Parameters.AddWithValue("@PlspDetails", table);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.NplPlspDetailType";

                    cmd.Parameters.AddWithValue("@ModifiedBy", Session.CurrentUser.Code);

                    var rows = await cmd.ExecuteNonQueryAsync();

                    return Response<int>.Success(rows, "Cập nhật plsp thành công");
                }
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }
    }
}
