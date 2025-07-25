using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using WHS.Core.Dto.Vehicle;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Receive;
using WHS.Core.Query.Vehicle;
using WHS.Core.Response;
using WHS.Repository.Interfaces;

namespace WHS.Repository.Repository.Vehicle
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        public VehicleRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Hàm lấy ra id mới nhất
        /// </summary>
        /// <returns></returns>
        public async Task<Response<int>> GetNewVehicleIdAsync()
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = "SELECT ISNULL(MAX(id), 0) + 1 FROM sys_vehicle";
                int nextId = await conn.ExecuteScalarAsync<int>(sql);

                return Response<int>.Success(nextId);
            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Thêm mới phương tiện
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<Response<int>> CreateVehicleAsync(VehicleDto vehicle)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"insert into sys_vehicle (id, vehicle_type, vehicle_mode, license_plate, seal_number, capacity, created_by, modified_by)
                            values (@ID, @VehicleType, @VehicleMode, @licensePlate, @SealNumber, @Capacity, @CreatedBy, @CreatedBy)
                            ";
                int id = await conn.ExecuteAsync(sql, new
                {
                    vehicle.ID,
                    vehicle.VehicleType,
                    vehicle.VehicleMode,
                    vehicle.LicensePlate,
                    SealNumber = vehicle.SealNumber ?? (object)DBNull.Value,
                    vehicle.Capacity,
                    CreatedBy = 0
                });

                return Response<int>.Success(id, "Tạo thành công phương tiện!");

            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Sửa phương tiện
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdateVehicleAsync(VehicleDto vehicle)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"update sys_vehicle
                            set vehicle_type = @VehicleType, 
                                vehicle_mode = @VehicleMode, 
                                license_plate = @licensePlate, 
                                seal_number = @SealNumber, 
                                capacity = @Capacity, 
                                modified_by = @ModifiedBy,
                                modified_at = GETDATE()
                            where id = @ID ";
                int id = await conn.ExecuteAsync(sql, new
                {
                    vehicle.ID,
                    vehicle.VehicleType,
                    vehicle.VehicleMode,
                    vehicle.LicensePlate,
                    SealNumber = vehicle.SealNumber ?? (object)DBNull.Value,
                    vehicle.Capacity,
                    ModifiedBy = 0
                });

                return Response<int>.Success(id, "Sửa phương tiện thành công!");

            }
            catch (Exception ex)
            {
                return ErrorHandler<int>.Show(ex);
            }
        }

        /// <summary>
        /// Láy ra phương tiện theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<VehicleDto>> GetVehicleByID(int id)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = "select id, vehicle_type, vehicle_mode, license_plate, seal_number, capacity from sys_vehicle where id = @id";
                VehicleDto? vehicle = await conn.QueryFirstOrDefaultAsync<VehicleDto>(sql, new {id});

                if (vehicle == null) return Response<VehicleDto>.Fail($"Không tìm thấy phương tiện nào có id là {id}");

                return Response<VehicleDto>.Success(vehicle);
            }
            catch (Exception ex) { 
                return ErrorHandler<VehicleDto>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách phương tiện 
        /// </summary>
        /// <param name="vehicleSearch"></param>
        /// <returns></returns>
        public async Task<Response<List<VehicleDto>>> GetVehicles(VehicleSearch vehicleSearch)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                // Bước1: Tạo dynamic filter
                var filters = new (string Sql, object? Value)[]
                {
                    ("vehicle_mode = @VehicleMode", vehicleSearch.VehicleMode != -1 ? vehicleSearch.VehicleMode : null),
                    ("license_plate like @Type", vehicleSearch.LincensePlate)
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
                    {
                        var paramName = f.Sql.Split('@')[1];
                        var paramValue = f.Sql.ToUpper().Contains("LIKE")
                            ? $"%{f.Value}%"
                            : f.Value;

                        parameters.Add(paramName, paramValue);
                    }
                }

                // Bước3: Get dữ liệu từ database
                string sql = @$"select id, vehicle_type, vehicle_mode, license_plate, seal_number, capacity
                               from sys_vehicle
                               {whereClause}";

                List<VehicleDto> items = (await conn.QueryAsync<VehicleDto>(sql, parameters)).ToList();

                return Response<List<VehicleDto>>.Success(items);
            }
            catch (Exception ex) { 
                return ErrorHandler<List<VehicleDto>>.Show(ex);
            }
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
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select 
                    transfer_id,
                    exec_status, 
                    transfer_status, 
                    vehicle_type, 
                    vehicle_mode, 
                    license_plate, 
                    seal_number, 
                    capacity
                from vw_npl_transfer_detail_vehicle
                where detail_type = @Type AND detail_id = @NplId";

                var parameters = new
                {
                    Type = type,
                    NplId = nplId
                };

                var result = (await conn.QueryAsync<TransferDetailVehicle>(sql, parameters)).ToList();

                return Response<List<TransferDetailVehicle>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<TransferDetailVehicle>>.Show(ex);
            }
        }
    }
}
