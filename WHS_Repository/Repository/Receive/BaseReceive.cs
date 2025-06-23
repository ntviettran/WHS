using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using WHS.Core.Dto.Receive;
using WHS.Core.Dto;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Repository.Interfaces;
using WHS.Core.Response;

namespace WHS.Repository.Repository.Receive
{
    public class BaseReceive : BaseRepository, IReceiveRepository
    {
        public BaseReceive(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lấy ra danh sách nhận NPL
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        public async Task<Response<PageDto<ReceiveDto>>> GetReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Bước1: Tạo dynamic filter
                var filters = new (string Sql, object? Value)[]
                {
                    ("mo LIKE @Mo", receiveSearch.MO),
                    ("npl_type LIKE @Type", (int)receiveSearch.Type)
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
                        parameters.Add(f.Sql.Split('@')[1], $"%{f.Value}%");
                }

                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                parameters.Add("Offset", offset);
                parameters.Add("PageSize", paginate.PageSize);

                // Buóc3: Tạo query
                string baseSql = "from npl_received";
                string countSql = $"select count(id) {baseSql} {whereClause};";
                string dataSql = $@"select id, mo, style, color, type_detail as typeDetail, supplier, quantity_to_receive as quantityToReceive, quantity_received as quantityReceived, quantity_estimate as quantityEstimate {baseSql}
                                    {whereClause}
                                    order by modified_at DESC
                                    offset @Offset rows fetch next @PageSize rows only;";

                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<ReceiveDto> items = (await conn.QueryAsync<ReceiveDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<ReceiveDto> result = new PageDto<ReceiveDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<ReceiveDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<ReceiveDto>>.Show(ex);
            }
        }
    }
}
