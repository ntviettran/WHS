using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WHS.Core.Dto;
using WHS.Core.Dto.Receive;
using WHS.Core.Dto.Transfer;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Query.Transfer;
using WHS.Core.Response;
using WHS.Repository.Interfaces;

namespace WHS.Repository.Repository.Coordinate
{
    public class BaseTransferRepository : BaseRepository, ITransferRepository
    {
        public BaseTransferRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lấy ra id mới của đợt chuyển
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> GetNewId()
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = "SELECT ISNULL(MAX(id), 0) + 1 FROM npl_transfer";
                int nextId = await conn.ExecuteScalarAsync<int>(sql);

                return Response<int>.Success(nextId);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Tạo phiếu diều phối
        /// </summary>
        /// <param name="transferData"></param>
        /// <param name="transferDetail"></param>
        /// <returns></returns>
        public async Task<Response<int>> CreateNewTransferAsync(TransferDto transferData, List<TransferDetailCreateDto> transferDetail)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var tran = conn.BeginTransaction();

            try
            {
                // Bước1: Insert vào npl_transfer và lấy ID
                var insertTransferSql = @"
                    insert into npl_transfer 
                        (id, vehicle_id, plan_exec_date, exec_date, plan_warehouse_date, warehouse_date, exec_status, transfer_status, created_by, modified_by)
                    output inserted.id
                    values 
                        (@ID, @VehicleId, @PlanExecDate, @ExecDate, @PlanWarehouseDate, @WarehouseDate, @ExecStatus, @TransferStatus, @CreatedBy, @CreatedBy);
                ";

                var transferId = await conn.ExecuteScalarAsync<int>(
                    insertTransferSql,
                    new
                    {
                        transferData.ID,
                        transferData.VehicleId,
                        transferData.PlanExecDate,
                        transferData.ExecDate,
                        transferData.PlanWarehouseDate,
                        transferData.WarehouseDate,
                        transferData.ExecStatus,
                        transferData.TransferStatus,
                        CreatedBy = 0
                    },
                    transaction: tran
                );

                // Bước 2: Convert List<TransferDetailCreateDto> to DataTable
                var detailTable = new DataTable();
                detailTable.Columns.Add("transfer_id", typeof(int));
                detailTable.Columns.Add("detail_type", typeof(int));
                detailTable.Columns.Add("detail_id", typeof(int));
                detailTable.Columns.Add("estimate_quantity", typeof(int));
                detailTable.Columns.Add("quantity_status", typeof(int));
                detailTable.Columns.Add("length_status", typeof(int));
                detailTable.Columns.Add("weight_status", typeof(int));
                detailTable.Columns.Add("created_by", typeof(int));
                detailTable.Columns.Add("modified_by", typeof(int));

                foreach (var detail in transferDetail)
                {
                    detailTable.Rows.Add(
                        transferId,
                        (int)detail.DetailType,
                        detail.DetailID,
                        detail.EstimateQuantity,
                        (int)detail.QuantityStatus,
                        (int)detail.LengthStatus,
                        (int)detail.WeightStatus,
                        0,
                        0
                    );
                }

                // Bước3: Bulk insert vào npl_transfer_detail
                using var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, (SqlTransaction)tran)
                {
                    DestinationTableName = "npl_transfer_detail"
                };

                bulkCopy.ColumnMappings.Add("transfer_id", "transfer_id");
                bulkCopy.ColumnMappings.Add("detail_type", "detail_type");
                bulkCopy.ColumnMappings.Add("detail_id", "detail_id");
                bulkCopy.ColumnMappings.Add("estimate_quantity", "estimate_quantity");
                bulkCopy.ColumnMappings.Add("quantity_status", "quantity_status");
                bulkCopy.ColumnMappings.Add("length_status", "length_status");
                bulkCopy.ColumnMappings.Add("weight_status", "weight_status");
                bulkCopy.ColumnMappings.Add("created_by", "created_by");
                bulkCopy.ColumnMappings.Add("modified_by", "modified_by");

                await bulkCopy.WriteToServerAsync(detailTable);
                await tran.CommitAsync();
                return Response<int>.Success(transferId);
            }
            catch (Exception ex)
            {
                await tran.RollbackAsync();
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Update transfer
        /// </summary>
        /// <param name="transferData"></param>
        /// <param name="transferDetail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdateTransferAsync(TransferDto transferData, List<TransferDetailCreateDto> transferDetail)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var tran = conn.BeginTransaction();

            try
            {
                //Bước1: Update npl_transfer
                var updateSql = @"
                update npl_transfer SET
                        vehicle_id = @VehicleId,
                        plan_exec_date = @PlanExecDate,
                        exec_date = @ExecDate,
                        plan_warehouse_date = @PlanWarehouseDate,
                        warehouse_date = @WarehouseDate,
                        exec_status = @ExecStatus,
                        transfer_status = @TransferStatus,
                        modified_by = @ModifiedBy,
                        modified_at = GETDATE()
                where id = @ID;
                    ";

                await conn.ExecuteAsync(updateSql, new
                {
                    transferData.ID,
                    transferData.VehicleId,
                    transferData.PlanExecDate,
                    transferData.ExecDate,
                    transferData.PlanWarehouseDate,
                    transferData.WarehouseDate,
                    transferData.ExecStatus,
                    transferData.TransferStatus,
                    ModifiedBy = 0
                }, transaction: tran);

                // Bước2: Tạo DataTable
                var table = new DataTable();
                table.Columns.Add("transfer_id", typeof(int));
                table.Columns.Add("detail_type", typeof(int));
                table.Columns.Add("detail_id", typeof(int));
                table.Columns.Add("estimate_quantity", typeof(int));
                table.Columns.Add("quantity_status", typeof(int));
                table.Columns.Add("length_status", typeof(int));
                table.Columns.Add("weight_status", typeof(int));
                table.Columns.Add("created_by", typeof(int));
                table.Columns.Add("modified_by", typeof(int));

                foreach (var d in transferDetail)
                {
                    table.Rows.Add(
                        transferData.ID,
                        (int)d.DetailType,
                        d.DetailID,
                        d.EstimateQuantity,
                        (int)d.QuantityStatus,
                        (int)d.LengthStatus,
                        (int)d.WeightStatus,
                        0,
                        0
                    );
                }

                // Gọi stored procedure với TVP
                var parameters = new DynamicParameters();
                parameters.Add("@Details", table.AsTableValuedParameter("dbo.TransferDetailTableType"));

                await conn.ExecuteAsync("viet_sp_upsert_transfer_detail", parameters, transaction: tran, commandType: CommandType.StoredProcedure);

                await tran.CommitAsync();
                return Response<int>.Success(transferData.ID);
            }
            catch (Exception ex)
            {
                await tran.RollbackAsync();
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Get dữ liệu chia theo page
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<PageDto<TransferDto>>> GetTransferByPageAsync(Paginate paginate, TransferSearch search)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Bước1: Tạo dynamic filter
                var filters = new (string Sql, object? Value)[]
                {
                    ("id = @ID", search.ID),
                    ("plan_exec_date = @EstimateExec", search.EstimateExec),
                    ("exec_date = @ExecDate", search.ExecDate),
                    ("plan_warehouse_date = @EstimateWarehouse", search.EstimateWarehouse),
                    ("warehouse_date = @WarehouseDate", search.WarehouseDate),
                    ("exec_status = @ExecStatus", (int)search.ExecStatus),
                };

                var whereList = filters
                    .Where(f => !string.IsNullOrWhiteSpace(f.Value?.ToString()))
                    .Select(f => f.Sql)
                    .ToList();

                var whereClause = whereList.Any() ? $"where {string.Join(" and ", whereList)}" : "";

                // Bước2: Add parameter
                var parameters = new DynamicParameters();
                foreach (var f in filters)
                {
                    if (!string.IsNullOrWhiteSpace(f.Value?.ToString()))
                        parameters.Add(f.Sql.Split('@')[1], $"{f.Value}");
                }

                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                parameters.Add("Offset", offset);
                parameters.Add("PageSize", paginate.PageSize);

                // Buóc3: Tạo query
                string baseSql = "from npl_transfer";
                string countSql = $"select count(id) {baseSql} {whereClause};";
                string dataSql = $@"select id, vehicle_id as VehicleId, plan_exec_date as PlanExecDate, exec_date as ExecDate, plan_warehouse_date as PlanWarehouseDate, warehouse_date as WarehouseDate, exec_status as ExecStatus, transfer_status as TransferStatus, created_at as CreatedAt {baseSql}
                                    {whereClause}
                                    order by modified_at DESC
                                    offset @Offset rows fetch next @PageSize rows only;";

                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<TransferDto> items = (await conn.QueryAsync<TransferDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<TransferDto> result = new PageDto<TransferDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<TransferDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<TransferDto>>.Show(ex);
            }
        }
    }
}
