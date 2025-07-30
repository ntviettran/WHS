using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Fabric;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Core.Session;

namespace WHS.Repository.Repository.Coordinate
{
    public class FabricTransferRepository : TransferRepository<FabricCoordinationDto, FabricTransferDetailDto>
    {
        public FabricTransferRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Lấy ra danh sách npl vải cần phải điều phối
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public override async Task<Response<List<FabricCoordinationDto>>> GetTransferCoordinateByStatus(E_DispatchTransfer status)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                mo,
                                style,
                                color,
                                fabric_type,
                                batch,
                                fabric_number
                                fabric_length,
                                fabric_weight,
                                length_received,
                                weight_received,
                                quantity_to_received,
                                received_quantity,
                                remaining_quantity,
                                status,
                                dispatch_status
                             from vw_npl_fabric_detail
                             where dispatch_status = @status and status <> 3 and factory_id = @FactoryID";

                List<FabricCoordinationDto> result = (await conn.QueryAsync<FabricCoordinationDto>(sql, new { status, Session.CurrentUser.FactoryID })).ToList();

                return Response<List<FabricCoordinationDto>>.Success(result);
            }
            catch (Exception ex) { 
                return ErrorHandler<List<FabricCoordinationDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách chi tiết npl vải đã điều phối theo id điều chuyển
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public override async Task<Response<List<FabricTransferDetailDto>>> GetTransferDetail(int transferId)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                transfer_detail_id,
                                mo,
                                style,
                                color,
                                fabric_type,
                                batch,
                                fabric_length,
                                fabric_weight,
                                roll_width,
                                fabric_number,
                                length_received,
                                weight_received,
                                quantity_to_received,
                                estimate_quantity,
                                received_quantity,
                                quantity_status,
                                length_status,
                                weight_status
                             from vw_npl_fabric_transfer_detail
                             where transfer_id = @transferId and factory_id = @FactoryID";

                List<FabricTransferDetailDto> ressult = (await conn.QueryAsync<FabricTransferDetailDto>(sql, new { transferId, Session.CurrentUser.FactoryID})).ToList();

                return Response<List<FabricTransferDetailDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<FabricTransferDetailDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách npl vải đã điều phối và cần điều phối theo id của npl vải cần nhận
        /// </summary>
        /// <param name="idNplReceived"></param>
        /// <returns></returns>
        public override async Task<Response<List<FabricCoordinationDto>>> GetCoordinationHistory(ReceiveHistorySearch search)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                const string sql = @"
                select 
                    style, 
                    color,
                    fabric_type, 
                    batch, 
                    fabric_length,
                    length_unit,
                    fabric_weight,
                    weight_unit,
                    roll_width,
                    fabric_number, 
                    length_received,
                    roll_width,
                    remaining_quantity,
                    quantity_to_received,
                    quantity_received,
                    status, 
                    dispatch_status
                from vw_npl_fabric_detail
                where id_npl_received = @idNplReceived
                      and (@status = -1 or status = @status)
                      and (@dispatchStatus = -1 or dispatch_status = @dispatchStatus)
                      and factory_id = @FactoryID";

                var param = new
                {
                    idNplReceived = search.ReceiveId,
                    status = search.Status,
                    dispatchStatus = search.DispatchStatus,
                    Session.CurrentUser.FactoryID
                };

                var result = (await conn.QueryAsync<FabricCoordinationDto>(sql, param)).ToList();

                return Response<List<FabricCoordinationDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<FabricCoordinationDto>>.Show(ex);
            }
        }
    }
}
