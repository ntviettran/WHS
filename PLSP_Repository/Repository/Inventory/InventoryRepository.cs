using Dapper;
using Microsoft.Extensions.Configuration;
using PLSP.Core.Dto.Location;
using PLSP.Core.Enums;
using PLSP.Core.Query.Location;
using PLSP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Repository.Repository;

namespace PLSP.Repository.Repository.Inventory
{
    public class InventoryRepository<T, D> : BaseRepository, IInventoryRepository<T, D>
        where T : class
        where D : class
    {
        public InventoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Ham này sẽ được override trong các repository cụ thể để lấy ra danh sách tồn kho theo phân trang.
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="mo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<PageDto<T>>> GetInventoryAsync(Paginate paginate, string mo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ham này sẽ được override trong các repository cụ thể để lấy ra danh sách tồn kho block theo phân trang.
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="mo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<PageDto<T>>> GetBlockAsync(Paginate paginate, string mo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy ra tổng quantity đã phân phối về vị trí
        /// </summary>
        /// <param name="nplId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> GetTotalQuantityLocation(int splitID)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string sql = "select sum(quantity) from vw_plsp_inventory_location where split_id = @SplitID and wh_type = @WhType and factory_id = @FactoryID";

                // Tạo paramers
                var parameters = new
                {
                    SplitID = splitID,
                    WhType = (int)Session.CurrentUser.GetCurrentType(),
                    Session.CurrentUser.FactoryID
                };

                // Lấy tổng
                int? total = await conn.QueryFirstOrDefaultAsync<int?>(sql, parameters);

                return Response<int>.Success(total ?? 0);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Hàm này sẽ được override trong các repository cụ thể để lấy ra danh sách vị trí tồn kho theo vị trí có phân trang.
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="mo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<PageDto<D>>> GetInventoryLocationsAsync(Paginate paginate, LocationSearch search)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Láy ra sản phẩm theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<Response<D>> GetInventoryLocationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<Response<List<D>>> UpdateLocationNpl(int splitId, int nplId, E_NPLType nplType, E_WHType whType, List<LocationDto> locations)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<QuantityPerLocation>>> GetQuantityPerLocation(int splitID)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Tạo query
                string sql = "select location, sum(quantity) as quantity from vw_plsp_inventory_location where split_id = @SplitID and wh_type = @WhType and factory_id = @FactoryID group by location";

                // Tạo paramers
                var parameters = new
                {
                    SplitID = splitID,
                    WhType = (int)Session.CurrentUser.GetCurrentType(),
                    Session.CurrentUser.FactoryID
                };

                // Lấy tổng
                List<QuantityPerLocation> result = (await conn.QueryAsync<QuantityPerLocation>(sql, parameters)).ToList();

                return Response<List<QuantityPerLocation>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<QuantityPerLocation>>.Show(ex);
            }
        }
    }
}
