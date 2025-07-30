using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PLSP.Core.Dto.Transaction;
using PLSP.Core.Enums;
using PLSP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.User;
using WHS.Core.ErrorHandle;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Repository.Repository;

namespace PLSP.Repository.Repository.Transaction
{
    public class BaseTransactionRepository : BaseRepository, ITransactionRepository
    {
        public BaseTransactionRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Xuất kho
        /// </summary>
        /// <param name="block"></param>
        /// <param name="transactions"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> InventoryExport(UserInfoDto userExport, List<TransactionCreateDto> transactions)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var tran = conn.BeginTransaction();

            try
            {
                string? area = userExport.Area;
                int code = userExport.Code;

                UserInfoDto user = Session.CurrentUser;
                E_WHType whType = user.GetCurrentType();

                var detailTable = new DataTable();
                detailTable.Columns.Add("area", typeof(string));
                detailTable.Columns.Add("code", typeof(int));
                detailTable.Columns.Add("type", typeof(int));
                detailTable.Columns.Add("location_id", typeof(int));
                detailTable.Columns.Add("npl_id", typeof(int));
                detailTable.Columns.Add("npl_type", typeof(int));
                detailTable.Columns.Add("transaction_type", typeof(int));
                detailTable.Columns.Add("quantity", typeof(int));
                detailTable.Columns.Add("created_by", typeof(int));
                detailTable.Columns.Add("modified_by", typeof(int));
                detailTable.Columns.Add("factory_id", typeof(int));

                foreach (var transaction in transactions)
                {
                    detailTable.Rows.Add(
                        area,
                        code,
                        (int)whType,
                        transaction.LocationId,
                        transaction.NplId,
                        (int)transaction.NplType,
                        (int)E_Transaction.EXPORT,
                        transaction.ExportQuantity,
                        Session.CurrentUser.Code,
                        Session.CurrentUser.Code,
                        Session.CurrentUser.FactoryID
                    );
                }

                // Bước3: Bulk insert vào npl_transfer_detail
                using var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, (SqlTransaction)tran)
                {
                    DestinationTableName = "sys_inventory_transaction"
                };

                bulkCopy.ColumnMappings.Add("area", "area");
                bulkCopy.ColumnMappings.Add("code", "code");
                bulkCopy.ColumnMappings.Add("type", "type");
                bulkCopy.ColumnMappings.Add("location_id", "location_id");
                bulkCopy.ColumnMappings.Add("npl_id", "npl_id");
                bulkCopy.ColumnMappings.Add("npl_type", "npl_type");
                bulkCopy.ColumnMappings.Add("transaction_type", "transaction_type");
                bulkCopy.ColumnMappings.Add("quantity", "quantity");
                bulkCopy.ColumnMappings.Add("created_by", "created_by");
                bulkCopy.ColumnMappings.Add("modified_by", "modified_by");
                bulkCopy.ColumnMappings.Add("factory_id", "factory_id");

                await bulkCopy.WriteToServerAsync(detailTable);
                await tran.CommitAsync();
                return Response<int>.Success(1);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Check limit số lượng của user mỗi ngày
        /// </summary>
        /// <param name="quantityLimit"></param>
        /// <param name="ssid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> CheckLimitQuantity(int quantityLimit, int code)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = "select sum(quantity) from sys_inventory_transaction where code = @Code and factory_id = @FactoryID and cast(created_at as date) = CAST(GETDATE() AS date)";
                
                int? total = conn.QueryFirstOrDefault<int?>(sql, new {Code = code, Session.CurrentUser.FactoryID});

                if (total == null || total < quantityLimit) { 
                    return Response<int>.Success(total ?? 0);
                }

                return Response<int>.Fail("Người này đã đạt giới hạn của ngày hôm nay!");
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }
    }
}
