using PLSP.Core.Dto.Location;
using PLSP.Core.Enums;
using PLSP.Core.Query.Location;
using PLSP.Repository.Interfaces;
using PLSP.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Enums;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Core.Session;

namespace PLSP.Service.Services.Inventory
{
    public class InventoryService<T, D> : IInventoryService<T, D>
        where T : class
        where D : class
    {
        private IInventoryRepository<T, D> _repository;

        public InventoryService(IInventoryRepository<T, D> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get danh sách tồn kho theo phân trang.
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="mo"></param>
        /// <returns></returns>
        public async Task<Response<PageDto<T>>> GetInventoryAsync(Paginate paginate, string mo)
        {
            return await _repository.GetInventoryAsync(paginate, mo);
        }

        /// <summary>
        /// Get danh sách tồn kho block theo phân trang.
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="mo"></param>
        /// <returns></returns>
        public async Task<Response<PageDto<T>>> GetBlockAsync(Paginate paginate, string mo)
        {
            return await _repository.GetBlockAsync(paginate, mo);
        }

        /// <summary>
        /// Tính tổng số lượng tồn đã chuyển đi vị trí
        /// </summary>
        /// <param name="nplId"></param>
        /// <param name="nplType"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> GetTotalQuantityLocation(int splitID)
        {
            return await _repository.GetTotalQuantityLocation(splitID);
        }

        /// <summary>
        /// Get danh sách tồn kho theo vị trí có phân trang.    
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<PageDto<D>>> GetInventoryLocationsAsync(Paginate paginate, LocationSearch search)
        {
            return await _repository.GetInventoryLocationsAsync(paginate, search); 
        }

        public async Task<Response<D>> GetInventoryLocationAsync(int id)
        {
            return await _repository.GetInventoryLocationAsync(id);
        }

        /// <summary>
        /// Chia nhỏ theo số lượng mỗi túi
        /// </summary>
        /// <param name="locations"></param>
        /// <returns></returns>
        public List<LocationDto> SplitLocations(List<LocationDto> locations)
        {
            var result = new List<LocationDto>();

            foreach (var loc in locations)
            {
                int fullBags = loc.Quantity / loc.QuantityPerBag;
                int remainder = loc.Quantity % loc.QuantityPerBag;

                for (int i = 0; i < fullBags; i++)
                {
                    result.Add(new LocationDto
                    {
                        Location = loc.Location,
                        Quantity = loc.QuantityPerBag,
                        QuantityPerBag = loc.QuantityPerBag
                    });
                }

                if (remainder > 0)
                {
                    result.Add(new LocationDto
                    {
                        Location = loc.Location,
                        Quantity = remainder,
                        QuantityPerBag = loc.QuantityPerBag
                    });
                }
            }

            return result;
        }

        /// <summary>
        /// Uodate vị trí (edit, delete, add) của npl
        /// </summary>
        /// <param name="nplId"></param>
        /// <param name="nplType"></param>
        /// <param name="whType"></param>
        /// <param name="locations"></param>
        /// <returns></returns>
        public async Task<Response<List<D>>> UpdateLocationNpl(int splitId, int nplId, E_NPLType nplType, List<LocationDto> locations)
        {
            E_WHType type = Session.CurrentUser.GetCurrentType();
            if (type == E_WHType.WAREHOUSE)
            {
                return await _repository.UpdateLocationNpl(splitId, nplId, nplType, type, locations);
            }

            List<LocationDto> newLocation = SplitLocations(locations);
            return await _repository.UpdateLocationNpl(splitId, nplId, nplType, type, newLocation);
        }

        public async Task<Response<List<QuantityPerLocation>>> GetQuantityPerLocation(int splitID)
        {
            return await _repository.GetQuantityPerLocation(splitID);
        }
    }
}
