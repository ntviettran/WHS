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
using WHS.Core.Dto.Receive;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Query.Transfer;
using WHS.Core.Response;
using WHS.Core.Session;
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
                string sql = "SELECT ISNULL(MAX(id), 0) + 1 FROM sys_npl_transfer";
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
                    insert into sys_npl_transfer 
                        (id, vehicle_id, plan_exec_date, plan_warehouse_date, exec_status, transfer_status, created_by, modified_by, factory_id)
                    output inserted.id
                    values 
                        (@ID, @VehicleId, @PlanExecDate, @PlanWarehouseDate, @ExecStatus, @TransferStatus, @CreatedBy, @CreatedBy, @FactoryID);
                ";

                var transferId = await conn.ExecuteScalarAsync<int>(
                    insertTransferSql,
                    new
                    {
                        transferData.ID,
                        transferData.VehicleId,
                        transferData.PlanExecDate,
                        transferData.PlanWarehouseDate,
                        transferData.ExecStatus,
                        transferData.TransferStatus,
                        CreatedBy = Session.CurrentUser.Code,
                        Session.CurrentUser.FactoryID
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
                detailTable.Columns.Add("factory_id", typeof(int));

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
                        Session.CurrentUser.Code,
                        Session.CurrentUser.Code,
                        Session.CurrentUser.FactoryID
                    );
                }

                // Bước3: Bulk insert vào npl_transfer_detail
                using var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.FireTriggers, (SqlTransaction)tran)
                {
                    DestinationTableName = "sys_npl_transfer_detail"
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
                bulkCopy.ColumnMappings.Add("factory_id", "factory_id");

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
                update sys_npl_transfer SET
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
                    ModifiedBy = Session.CurrentUser.Code
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
                    ("exec_status = @ExecStatus", search.ExecStatus is int status && status != -1 ? search.ExecStatus : null),
                    ("factory_id = @FactoryID", Session.CurrentUser.FactoryID),
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
                string baseSql = "from sys_npl_transfer";
                string countSql = $"select count(id) {baseSql} {whereClause};";
                string dataSql = $@"select id, vehicle_id, plan_exec_date, exec_date, plan_warehouse_date, warehouse_date, exec_status, transfer_status, created_at {baseSql}
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

        /// <summary>
        /// Update ngày thực hiện là ngày khi gọi hàm
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public async Task<Response<int>> UpdateExecDate(int transferId)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = $"update sys_npl_transfer set exec_date = getdate(), exec_status = {(int)E_TransferExec.DOING} where id = @transferId and factory_id = @FactoryID";
                int result = await conn.ExecuteScalarAsync<int>(sql, new { transferId, Session.CurrentUser.FactoryID});

                return Response<int>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Update ngày về kho là ngày khi gọi hàm
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public async Task<Response<int>> UpdateWarhouseDate(int transferId)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = $"update sys_npl_transfer set warehouse_date = getdate(), exec_status = {(int)E_TransferExec.DONE}, transfer_status = {(int)E_TransferStatus.SUCCESS} where id = @transferId";
                int result = await conn.ExecuteScalarAsync<int>(sql, new { transferId });

                return Response<int>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Xác nhận về kho thất bại
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public async Task<Response<int>> UpdateTransferStatus(int transferId, E_TransferStatus status)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = $"update sys_npl_transfer set transfer_status = {(int)status} where id = @transferId";
                int result = await conn.ExecuteScalarAsync<int>(sql, new { transferId });

                return Response<int>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Update số lượng thực tế nhận được
        /// </summary>
        /// <param name="fabricDetail"></param>
        /// <param name="plspDetail"></param>
        /// <param name="pldgDetail"></param>
        /// <returns></returns>
        public async Task<Response<int>> UpdateQuantityTransfer(List<TransferQuantityDetailDto> allDetails)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Bước1: Chuẩn bị DataTable khớp với TransferQuantityType
                var table = new DataTable();
                table.Columns.Add("id", typeof(int));
                table.Columns.Add("received_quantity", typeof(int));
                table.Columns.Add("length_received", typeof(float));
                table.Columns.Add("weight_received", typeof(float));
                table.Columns.Add("quantity_status", typeof(int));
                table.Columns.Add("length_status", typeof(int));
                table.Columns.Add("weight_status", typeof(int));

                foreach (var item in allDetails)
                {
                    table.Rows.Add(
                        item.ID,
                        item.ReceivedQuantity,
                        item.LengthReceived,
                        item.WeightReceived,
                        (int)item.QuantityStatus,
                        (int)item.LengthStatus,
                        (int)item.WeightStatus
                    );
                }

                // Bước2: Câu lệnh SQL sử dụng JOIN với TVP
                string sql = @"
                merge into sys_npl_transfer_detail AS target
                using @TransferData AS source
                on target.id = source.id
                when MATCHED then
                    update set
                        target.received_quantity = source.received_quantity,
                        target.length_received = source.length_received,
                        target.weight_received = source.weight_received,
                        target.quantity_status = source.quantity_status,
                        target.length_status = source.length_status,
                        target.weight_status = source.weight_status,
                        target.modified_by = @ModifiedBy,
                        target.modified_at = GETDATE();
                ";

                // Bước3: Truyền TVP vào Dapper
                var parameters = new DynamicParameters();
                parameters.Add("@TransferData", table.AsTableValuedParameter("dbo.TransferQuantityType"));
                parameters.Add("ModifiedBy", Session.CurrentUser.Code);

                int result = await conn.ExecuteAsync(sql, parameters);

                return Response<int>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Cancel các đợt chuyển
        /// </summary>
        /// <param name="transferIds"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> CancelTransfers(List<int> transferIds)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            try 
            { 
                var sql = @"
                    update sys_npl_transfer
                    set exec_status = @CancelStatus,
                        modified_by = @ModifiedBy,
                        modified_at = GETDATE()
                    where id IN @Ids and transfer_status <> 1";

                var parameters = new DynamicParameters();
                parameters.Add("CancelStatus", E_TransferExec.CANCEL);
                parameters.Add("Ids", transferIds);
                parameters.Add("ModifiedBy", Session.CurrentUser.Code);

                var rowsAffected = await conn.ExecuteAsync(sql, parameters);

                return Response<int>.Success(rowsAffected);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }   
    }
}
