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
    public class PldgReceiveRepository : ReceiveRepository<PldgDto, PldgReceivedDto>
    {
        public PldgReceiveRepository(IConfiguration configuration) : base(configuration)
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
                string baseSql = "from vw_grouped_pldg_received";
                string countSql = $"select count(mo) {baseSql} where @Mo is null or mo like @Mo;";
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
        /// Get dữ liệu chi tiết
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<PageDto<PldgReceivedDto>>> GetDetailReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string baseSql = "from vw_npl_pldg_detail";
                string whereClause = @"where (@Mo is null or mo like @Mo) and
                                             (@Status is null or status = @Status) and
                                             (@DispatchStatus is null or dispatch_status = @DispatchStatus)";
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
                    DispatchStatus = receiveSearch.DispatchStatus == -1 ? null : receiveSearch.DispatchStatus
                };

                // Lấy số lượng bản ghi và dữ liệu
                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<PldgReceivedDto> items = (await conn.QueryAsync<PldgReceivedDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<PldgReceivedDto> result = new PageDto<PldgReceivedDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<PldgReceivedDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<PldgReceivedDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Check duplicate giá trị detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public override async Task<Response<bool>> CheckDuplicateValue(DataTable detail)
        {
            var columnChecks = new List<string>
            {
                "MO", "Supplier", "PldgType", "PldgCode", "PoCode", "PldgSize", "Color"
            };

            string sqlCheck = @"
                select distinct t.keyhash
                from #tempkeys t
                join sys_npl_pldg_received r on
                    t.keyhash collate sql_latin1_general_cp1_ci_as = lower(concat_ws('||',
                        isnull(r.mo, ''),
                        isnull(r.supplier, ''),
                        isnull(r.pldg_type, ''),
                        isnull(r.pldg_code, ''),
                        isnull(r.po_code, ''),
                        isnull(r.pldg_size, ''),
                        isnull(r.color, '')
                    ))
                ";

            return await CheckDuplicateBase(detail, columnChecks, sqlCheck);
        }

        /// <summary>
        /// Check xem có dữ liệu nào đã điều phối chưa
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<bool>> CheckHasDispatch(List<int> ids)
        {
            return await CheckHasDispatchBase(ids, "vw_npl_pldg_detail");
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
                    bulkCopy.DestinationTableName = "sys_npl_pldg_received";

                    // Ánh xạ cột
                    bulkCopy.ColumnMappings.Add("MO", "mo");
                    bulkCopy.ColumnMappings.Add("Supplier", "supplier");
                    bulkCopy.ColumnMappings.Add("PldgType", "pldg_type");
                    bulkCopy.ColumnMappings.Add("PldgCode", "pldg_code");
                    bulkCopy.ColumnMappings.Add("PoCode", "po_code");
                    bulkCopy.ColumnMappings.Add("QuantityPerCarton", "quantity_per_carton");
                    bulkCopy.ColumnMappings.Add("NetWeight", "net_weight");
                    bulkCopy.ColumnMappings.Add("GrossWeight", "gross_weight");
                    bulkCopy.ColumnMappings.Add("Color", "color");
                    bulkCopy.ColumnMappings.Add("PldgWeight", "pldg_weight");
                    bulkCopy.ColumnMappings.Add("WeightUnit", "weight_unit");
                    bulkCopy.ColumnMappings.Add("PldgSize", "pldg_size");
                    bulkCopy.ColumnMappings.Add("SizeUnit", "size_unit");
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
        /// Lấy ra detail chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<List<PldgReceivedDto>>> GetReceiveDetailAsync(GroupReceiveDto receiveData)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select *
                from vw_npl_pldg_detail
                where (@MO is null or mo = @MO) and 
                    (@TypeDetail is null or pldg_type = @TypeDetail) and 
                    (@Supplier is null or supplier = @Supplier)";

                var parameters = new
                {
                    receiveData.MO,
                    receiveData.TypeDetail,
                    receiveData.Supplier
                };

                var result = (await conn.QueryAsync<PldgReceivedDto>(sql, parameters)).ToList();
                return Response<List<PldgReceivedDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PldgReceivedDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách dữ liệu chưa điều phối
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async override Task<Response<List<PldgDto>>> GetListReceiveAsync()
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select id, mo, supplier, pldg_type, po_code, quantity_per_carton, net_weight, 
                    gross_weight, color, pldg_weight, weight_unit, pldg_size, size_unit, quantity_to_received,
                    order_date, available_date, expected_date, is_cancelled
                from vw_npl_pldg_detail
                where status = 0 or status = 3";

                var result = (await conn.QueryAsync<PldgDto>(sql)).ToList();
                return Response<List<PldgDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PldgDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Update chi tiết npl chưa điều phối
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<Response<int>> UpdateReceivedDetail(List<PldgDto> data)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                var table = new DataTable();

                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("MO", typeof(string));
                table.Columns.Add("Supplier", typeof(string));
                table.Columns.Add("PldgType", typeof(string));
                table.Columns.Add("PldgCode", typeof(string));
                table.Columns.Add("PoCode", typeof(string));
                table.Columns.Add("QuantityPerCarton", typeof(int));
                table.Columns.Add("NetWeight", typeof(float));
                table.Columns.Add("GrossWeight", typeof(float));
                table.Columns.Add("Color", typeof(string));
                table.Columns.Add("PldgWeight", typeof(float));
                table.Columns.Add("WeightUnit", typeof(string));
                table.Columns.Add("PldgSize", typeof(string));
                table.Columns.Add("SizeUnit", typeof(string));
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
                        item.PldgType,
                        item.PldgCode,
                        item.PoCode,
                        item.QuantityPerCarton,
                        item.NetWeight,
                        item.GrossWeight,
                        item.Color,
                        item.PldgWeight,
                        item.WeightUnit,
                        item.PldgSize,
                        item.SizeUnit,
                        item.QuantityToReceived,
                        item.OrderDate ?? (object)DBNull.Value,
                        item.AvailableDate ?? (object)DBNull.Value,
                        item.ExpectedDate ?? (object)DBNull.Value,
                        item.IsCancelled ?? (object)DBNull.Value
                    );
                }

                using (var cmd = new SqlCommand("viet_sp_update_pldg_received", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var param = cmd.Parameters.AddWithValue("@@PldgDetails", table);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.NplPldgDetailType";

                    cmd.Parameters.AddWithValue("@ModifiedBy", 0);

                    var rows = await cmd.ExecuteNonQueryAsync();

                    return Response<int>.Success(rows, "Cập nhật pldg thành công");
                }
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }
    }
}
