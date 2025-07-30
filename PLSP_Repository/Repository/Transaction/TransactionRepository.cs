using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PLSP.Core.Dto.PLSP;
using PLSP.Core.Dto.Transaction;
using PLSP.Core.Enums;
using PLSP.Core.Query.Transaction;
using PLSP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Core.Session;

namespace PLSP.Repository.Repository.Transaction
{
    public class TransactionRepository<T> : BaseTransactionRepository, ITransactionRepository<T>
    {
        public TransactionRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lấy ra lích sử giao dịch
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<Response<PageDto<T>>> GetHistoryTransactionInventory(Paginate paginate, HistorySearch search)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                E_WHType type = Session.CurrentUser.GetCurrentType();

                // Tạo where clause linh hoạt theo type
                var whereConditions = new List<string>
                {
                    "(@Mo is null or mo like @Mo)",
                    "(@Location is null or location like @Location)",
                    "(@CreatedAt is null or CAST(created_at AS DATE) = @CreatedAt)",
                    "type = @Type",
                    "factory_id = @FactoryID"
                };

                if (type == E_WHType.WAREHOUSE)
                {
                    whereConditions.Insert(1, "(@Area is null or area like @Area)");
                }
                else if (type == E_WHType.BLOCK)
                {
                    whereConditions.Insert(1, "(@Code is null or code = @Code)");
                    whereConditions.Insert(1, "area = @Area");
                }

                string whereClause = "where " + string.Join(" and ", whereConditions);

                string baseSql = "from vw_inventory_transaction";
                string countSql = $"select count(id) {baseSql} {whereClause};";
                string dataSql = $@"select * {baseSql}
                            {whereClause}
                            order by created_at desc
                            offset @Offset rows fetch next @PageSize rows only;";

                int offset = (paginate.PageIndex - 1) * paginate.PageSize;

                var parameters = new DynamicParameters();
                parameters.Add("Offset", offset);
                parameters.Add("PageSize", paginate.PageSize);
                parameters.Add("Mo", string.IsNullOrEmpty(search.MO) ? null : $"%{search.MO}%");
                parameters.Add("Location", string.IsNullOrEmpty(search.Location) ? null : $"%{search.Location}%");
                parameters.Add("CreatedAt", search.CreatedAt);
                parameters.Add("Type", (int)type);
                parameters.Add("FactoryID", Session.CurrentUser.FactoryID);

                if (type == E_WHType.WAREHOUSE)
                    parameters.Add("Area", string.IsNullOrEmpty(search.Area) ? null : $"%{search.Area}%");
                else if (type == E_WHType.BLOCK)
                {
                    parameters.Add("Code", string.IsNullOrEmpty(search.Code) ? null : search.Code);
                    parameters.Add("Area", Session.CurrentUser.Area);
                }

                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                var items = (await conn.QueryAsync<T>(dataSql, parameters)).ToList();

                var result = new PageDto<T>
                {
                    TotalPage = (int)Math.Ceiling(total / (double)paginate.PageSize),
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<T>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<T>>.Show(ex);
            }
        }
    }
}
