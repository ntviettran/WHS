using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.PO;
using WHS.Core.Dto.Receive;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Repository.Interfaces;

namespace WHS.Repository.Repository.PO
{
    public class PORepository : BaseRepository, IPORepository
    {
        public PORepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Tạo mới một PO
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        public async Task<Response<int>> CreatedNewPO(POCreateDto po)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"insert into po (po, mo, country_code, id_item, created_by, modified_by)
                                output INSERTED.id
                                values (@PO, @MO, @CountryCode, @IdItem, @CreatedBy, @CreatedBy);";

                var parameters = new
                {
                    po.PO,
                    po.MO,
                    po.CountryCode,
                    po.IdItem,
                    CreatedBy = 0
                };

                int newId = await conn.QuerySingleAsync<int>(sql, parameters);
                return Response<int>.Success(newId);

            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Update PO
        /// </summary>
        /// <param name="id"></param>
        /// <param name="po"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdatePO(int id, POCreateDto po)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                    UPDATE po
                    SET po = @PO,
                        mo = @MO,
                        country_code = @CountryCode,
                        id_item = @IdItem,
                        modified_by = @ModifiedBy,
                        modified_at = GetDate()
                    WHERE id = @Id;";

                var parameters = new
                {
                    Id = id,
                    po.PO,
                    po.MO,
                    po.CountryCode,
                    po.IdItem,
                    ModifiedBy = 0
                };

                int affectedRows = await conn.ExecuteAsync(sql, parameters);
                return Response<int>.Success(affectedRows);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Get Po theo trang
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="po"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<PageDto<PODto>>> GetPoAsync(Paginate paginate, string po)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {

                // Bước1: Add parameter
                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                var parameters = new
                {
                    Po = $"%{po}%",
                    Offset = offset,
                    paginate.PageSize
                };

                // Buóc2: Tạo query
                string baseSql = "from po";
                string whereClause = string.IsNullOrWhiteSpace(po) ? "" : "where po LIKE @Po";
                string countSql = $"select count(id) {baseSql} {whereClause};";
                string dataSql = $@"select id, po, mo, country_code, id_item {baseSql}
                                    {whereClause}
                                    order by modified_at DESC
                                    offset @Offset rows fetch next @PageSize rows only;";

                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<PODto> items = (await conn.QueryAsync<PODto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<PODto> result = new PageDto<PODto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<PODto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<PODto>>.Show(ex);
            }
        }
    }
}
