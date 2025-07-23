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
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Repository.Interfaces;

namespace WHS.Repository.Repository.Receive
{
    public class ReceiveRepository<T, D> : BaseRepository, IReceiveRepository<T, D>
        where T : class
        where D : class
    {
        public ReceiveRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Get dữ liệu grouped theo mo
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<PageDto<GroupReceiveDto>>> GetGroupedReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check xem có trùng giá trị không
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<bool>> CheckDuplicateValue(DataTable detail)
        {
            throw new NotImplementedException();
        }

        /// <summary>   
        /// Tạo mới phiếu NPL, xử lí ở class con
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public virtual Task<Response<int>> CreateReceiveAsync(DataTable detail)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Chỉnh sửa phiếu NPL
        /// </summary>
        /// <param name="data"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<int>> UpdateReceiveAsync(int id, DataTable detail)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy ra detail chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<List<D>>> GetReceiveDetailAsync(GroupReceiveDto receiveData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Base check trùng dữ liệu (gọi cho các class con)
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="columnChecks"></param>
        /// <param name="sqlCheck"></param>
        /// <returns></returns>
        public async Task<Response<bool>> BaseCheckDuplicate(DataTable detail, List<string> columnChecks, string sqlCheck)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var transaction = conn.BeginTransaction();

            try
            {
                // Tạo cột KeyHash để kiểm tra trùng
                if (!detail.Columns.Contains("KeyHash"))
                    detail.Columns.Add("KeyHash", typeof(string));

                foreach (DataRow row in detail.Rows)
                {
                    var key = string.Join("||", columnChecks.Select(col => row[col]?.ToString()?.Trim().ToLower() ?? ""));
                    row["KeyHash"] = key;
                }

                // Tạo bảng tạm để chứa KeyHash
                var tempKeyTable = new DataTable();
                tempKeyTable.Columns.Add("KeyHash", typeof(string));
                foreach (DataRow row in detail.Rows)
                    tempKeyTable.Rows.Add(row["KeyHash"]);

                // Tạo bảng tạm trên SQL
                using (var createCmd = new SqlCommand("CREATE TABLE #TempKeys (KeyHash NVARCHAR(1000))", conn, transaction))
                {
                    await createCmd.ExecuteNonQueryAsync();
                }

                // Đẩy key xuống bảng tạm
                using (var bulkKey = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                {
                    bulkKey.DestinationTableName = "#TempKeys";
                    bulkKey.ColumnMappings.Add("KeyHash", "KeyHash");
                    await bulkKey.WriteToServerAsync(tempKeyTable);
                }

                var existingKeys = new HashSet<string>();
                using (var checkCmd = new SqlCommand(sqlCheck, conn, transaction))
                using (var reader = await checkCmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        existingKeys.Add(reader.GetString(0));
                    }
                }

                if (existingKeys.Any())
                {
                    var duplicatedRows = new List<int>();
                    for (int i = 0; i < detail.Rows.Count; i++)
                    {
                        if (existingKeys.Contains(detail.Rows[i]["KeyHash"].ToString()!))
                            duplicatedRows.Add(i + 1);
                    }

                    transaction.Rollback();
                    return Response<bool>.Fail("Dữ liệu bị trùng tại các dòng: " + string.Join(", ", duplicatedRows));
                }

                return Response<bool>.Success(true, "Không có dữ liệu trùng lặp.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return ErrorHandler<bool>.Show(ex);
            }
        }

        public async Task<Response<int>> UpdateReceiveBaseAsync(
            int id,
            string updateSql,
            object parentParams,
            DataTable detail,
            string procedureName,
            string tableTypeName)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var transaction = conn.BeginTransaction();

            try
            {
                // Thêm cột nếu thiếu
                if (!detail.Columns.Contains("Id"))
                {
                    var idColumn = new DataColumn("Id", typeof(int));
                    detail.Columns.Add(idColumn);
                    idColumn.SetOrdinal(0);
                }

                if (!detail.Columns.Contains("ModifiedBy"))
                    detail.Columns.Add("ModifiedBy", typeof(int));

                foreach (DataRow row in detail.Rows)
                {
                    row["ModifiedBy"] = 0;
                }

                // Gọi procedure
                await conn.ExecuteAsync(
                    procedureName,
                    new
                    {
                        Details = detail.AsTableValuedParameter(tableTypeName),
                        IdNplReceived = id
                    },
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure
                );

                transaction.Commit();
                return Response<int>.Success(id, "Sửa NPL thành công!");
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }
    }
}
