using Dapper;
using Microsoft.Extensions.Configuration;
using PLSP.Core.Dto.Location;
using PLSP.Core.Dto.PLSP;
using PLSP.Core.Enums;
using PLSP.Core.Query.Location;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Repository.Repository;

namespace PLSP.Repository.Repository.Inventory
{
    public class PLSPInventoryRepository : InventoryRepository<PlspInventoryDto, PlspInventoryLocationDto>
    {
        public PLSPInventoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lấy ra danh sách tồn kho PLSP theo page
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="mo"></param>
        /// <returns></returns>
        public async override Task<Response<PageDto<PlspInventoryDto>>> GetInventoryAsync(Paginate paginate, string mo)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string baseSql = "from vw_npl_plsp_inventory";
                string countSql = $"select count(id) {baseSql} where (@Mo is null or mo like @Mo) and factory_id = @FactoryID;";
                string dataSql = $@"select * {baseSql}
                                    where (@Mo is null or mo like @Mo) and factory_id = @FactoryID
                                    order by id
                                    offset @Offset rows fetch next @PageSize rows only;";

                // Tạo paramers
                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                var parameters = new
                {
                    Offset = offset,
                    paginate.PageSize,
                    Mo = string.IsNullOrEmpty(mo) ? null : $"%{mo}%",
                    Session.CurrentUser.FactoryID
                };

                // Lấy số lượng bản ghi và dữ liệu
                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<PlspInventoryDto> items = (await conn.QueryAsync<PlspInventoryDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<PlspInventoryDto> result = new PageDto<PlspInventoryDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<PlspInventoryDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<PlspInventoryDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách tồn kho block theo page
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="mo"></param>
        /// <returns></returns>
        public async override Task<Response<PageDto<PlspInventoryDto>>> GetBlockAsync(Paginate paginate, string mo)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string baseSql = "from vw_npl_plsp_block";
                string countSql = $"select count(id) {baseSql} where (@Mo is null or mo like @Mo) and area = @Area and factory_id = @FactoryID;";
                string dataSql = $@"select * {baseSql}
                                    where (@Mo is null or mo like @Mo) and area = @Area and factory_id = @FactoryID
                                    order by id
                                    offset @Offset rows fetch next @PageSize rows only;";

                // Tạo paramers
                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                var parameters = new
                {
                    Offset = offset,
                    paginate.PageSize,
                    Mo = string.IsNullOrEmpty(mo) ? null : $"%{mo}%",
                    Session.CurrentUser.Area,
                    Session.CurrentUser.FactoryID
                };

                // Lấy số lượng bản ghi và dữ liệu
                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<PlspInventoryDto> items = (await conn.QueryAsync<PlspInventoryDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<PlspInventoryDto> result = new PageDto<PlspInventoryDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<PlspInventoryDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<PlspInventoryDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách vị trí tồn kho PLSP có vị trí theo page và tìm kiếm
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async override Task<Response<PageDto<PlspInventoryLocationDto>>> GetInventoryLocationsAsync(Paginate paginate, LocationSearch search)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string whereClause = @"where (@Mo is null or mo like @Mo) 
                                       and (@Location is null or location like @Location)
                                       and (@Area is null or area = @Area)
                                       and wh_type = @WhType
                                       and factory_id = @FactoryID";
                string baseSql = "from vw_plsp_inventory_location";
                string countSql = $"select count(id) {baseSql} {whereClause};";
                string dataSql = $@"select * {baseSql}
                                    {whereClause}
                                    order by id
                                    offset @Offset rows fetch next @PageSize rows only;";

                // Tạo paramers
                int offset = (paginate.PageIndex - 1) * paginate.PageSize;
                var parameters = new
                {
                    Offset = offset,
                    paginate.PageSize,
                    Mo = string.IsNullOrEmpty(search.MO) ? null : $"%{search.MO}%",
                    Location = string.IsNullOrEmpty(search.Location) ? null : $"%{search.Location}%",
                    Session.CurrentUser.Area,
                    WhType = (int)Session.CurrentUser.GetCurrentType(),
                    Session.CurrentUser.FactoryID
                };

                // Lấy số lượng bản ghi và dữ liệu
                var total = await conn.ExecuteScalarAsync<int>(countSql, parameters);
                List<PlspInventoryLocationDto> items = (await conn.QueryAsync<PlspInventoryLocationDto>(dataSql, parameters)).ToList();

                int totalPages = (int)Math.Ceiling(total / (double)paginate.PageSize);
                PageDto<PlspInventoryLocationDto> result = new PageDto<PlspInventoryLocationDto>()
                {
                    TotalPage = totalPages,
                    TotalRecord = total,
                    PageData = items
                };

                return Response<PageDto<PlspInventoryLocationDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PageDto<PlspInventoryLocationDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Láy ra sản phẩm theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async override Task<Response<PlspInventoryLocationDto>> GetInventoryLocationAsync(int id)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string sql = "select * from vw_plsp_inventory_location where id = @ID and wh_type = @WhType and factory_id = @FactoryID";

                var parameters = new { 
                    ID =id,
                    WhType = (int)Session.CurrentUser.GetCurrentType(),
                    Session.CurrentUser.FactoryID
                };

                // Lấy số lượng bản ghi và dữ liệu
                PlspInventoryLocationDto? item = await conn.QuerySingleOrDefaultAsync<PlspInventoryLocationDto>(sql, parameters);

                if (item == null)
                {
                    return Response<PlspInventoryLocationDto>.Fail("NPL không tồn tại hoặc đã xuất hết khỏi kho!");
                }

                return Response<PlspInventoryLocationDto>.Success(item);
            }
            catch (Exception ex)
            {
                return ErrorHandler<PlspInventoryLocationDto>.Show(ex);
            }
        }

        /// <summary>
        /// Update vị trí NPL (thêm, sửa, xóa).
        /// </summary>
        /// <param name="locations"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async override Task<Response<List<PlspInventoryLocationDto>>> UpdateLocationNpl(int splitId, int nplId, E_NPLType nplType, E_WHType whType, List<LocationDto> locations)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo TVP từ danh sách
                var table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Location", typeof(string));
                table.Columns.Add("Quantity", typeof(int));

                foreach (var loc in locations)
                {
                    table.Rows.Add(loc.ID, loc.Location, loc.Quantity);
                }

                // Tạo DynamicParams
                var parameters = new DynamicParameters();
                parameters.Add("@SplitId", splitId);
                parameters.Add("@NplId", nplId);
                parameters.Add("@NplType", (int)nplType);
                parameters.Add("@WhType", (int)whType);
                parameters.Add("@Area", Session.CurrentUser.Area);
                parameters.Add("@CreatedBy", Session.CurrentUser.Code);
                parameters.Add("@FactoryID", Session.CurrentUser.FactoryID);
                parameters.Add("@Locations", table.AsTableValuedParameter("dbo.NPLLocationType"));

                // Gọi procedure
                var result = (await conn.QueryAsync<PlspInventoryLocationDto>("viet_sp_upsert_location", parameters, commandType: CommandType.StoredProcedure)).ToList();
                return Response<List<PlspInventoryLocationDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PlspInventoryLocationDto>>.Show(ex);
            }
        }
    }
}
