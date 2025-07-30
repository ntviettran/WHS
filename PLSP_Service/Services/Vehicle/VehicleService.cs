using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Vehicle;
using WHS.Core.Enums;
using WHS.Core.Query.Vehicle;
using WHS.Core.Response;
using WHS.Repository.Interfaces;
using WHS.Repository.Repository.Coordinate;
using WHS.Service.Interface;

namespace WHS.Service.Services.Vehicle
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        /// <summary>
        /// Hàm lấy ra id mới nhất của bảng phương tiện
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> GetNewVehicleIdAsync()
        {
            return await _vehicleRepository.GetNewVehicleIdAsync();
        }

        /// <summary>
        /// Thực hiện thêm mới phương tiện
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> CreateVehicleAsync(VehicleDto vehicle)
        {
            return await _vehicleRepository.CreateVehicleAsync(vehicle);
        }

        /// <summary>
        /// Sửa phương tiện
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<Response<int>> UpdateVehicleAsync(VehicleDto vehicle)
        {
            return await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        /// <summary>
        /// Lấy ra phương tiện theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<VehicleDto>> GetVehicleByID(int id)
        {
            return await _vehicleRepository.GetVehicleByID(id);
        }

        /// <summary>
        /// Lấy ra danh sách phương tiện
        /// </summary>
        /// <param name="vehicleSearch"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<List<VehicleDto>>> GetVehicles(VehicleSearch vehicleSearch)
        {
            return await _vehicleRepository.GetVehicles(vehicleSearch);
        }

        /// <summary>
        /// Lấy ra danh sách phương tiện theo trạng thái
        /// </summary>
        /// <param name="type"></param>
        /// <param name="nplId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<List<TransferDetailVehicle>>> GetVehicleTransferDetail(E_NPLType type, int nplId)
        {
            return await _vehicleRepository.GetVehicleTransferDetail(type, nplId);
        }
    }
}
