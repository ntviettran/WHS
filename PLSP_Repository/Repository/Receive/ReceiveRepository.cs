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
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Core.Session;
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
        /// Lấy ra danh sách chi tiết
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<PageDto<D>>> GetDetailReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
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
        public async Task<Response<bool>> CheckDuplicateBase(DataTable detail, List<string> columnChecks, string sqlCheck)
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
                    var key = string.Join("||", columnChecks.Select(col => row[col]?.ToString()?.Trim().ToLower() ?? "").Concat(new[] { Session.CurrentUser.FactoryID.ToString() }));
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

        /// <summary>
        /// Lấy ra danh sách dữ liệu chưa điều phối
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<List<T>>> GetListReceiveAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Base check xem có dữ liệu nào đã điều phối chưa
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<bool>> CheckHasDispatchBase(List<int> ids, string table)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @$"
                select id FROM {table}
                where (status = 1 or status = 2) and factory_id = @FactoryID and id IN @Ids";

                var dispatched = (await conn.QueryAsync<int>(sql, new { Ids = ids, Session.CurrentUser.FactoryID })).ToList();
                bool hasDispatched = dispatched.Any();

                if (!hasDispatched)
                {
                    return Response<bool>.Success(false, "Không có dữ liệu đã điều phối.");
                }

                var message = $"Không thể update do ID {string.Join(", ", dispatched)} đã điều phối";
                return Response<bool>.Fail(message);
            }
            catch (Exception ex)
            {
                return ErrorHandler<bool>.Show(ex);
            }
        }

        /// <summary>
        /// Check xem có dữ liệu nào đã điều phối chưa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<bool>> CheckHasDispatch(List<int> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update chi tiết npl chưa điều phối
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<int>> UpdateReceivedDetail(List<T> data)
        {
            throw new NotImplementedException();
        }

    }
}
