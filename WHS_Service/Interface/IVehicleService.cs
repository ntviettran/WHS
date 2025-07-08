using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Vehicle;
using WHS.Core.Query.Vehicle;
using WHS.Core.Response;

namespace WHS.Service.Interface
{
    public interface IVehicleService
    {
        /// <summary>
        /// Hàm lấy ra id mới nhất của bảng phương tiện
        /// </summary>
        /// <returns></returns>
        Task<Response<int>> GetNewVehicleIdAsync();

        /// <summary>
        /// Thêm mới phương tiện
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        Task<Response<int>> CreateVehicleAsync(VehicleDto vehicle);

        /// <summary>
        /// Lấy ra phương tiện theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<VehicleDto>> GetVehicleByID(int id);

        /// <summary>
        /// Lấy ra danh sách phương tiện
        /// </summary>
        /// <param name="vehicleSearch"></param>
        /// <returns></returns>
        Task<Response<List<VehicleDto>>> GetVehicles(VehicleSearch vehicleSearch);
    }
}
