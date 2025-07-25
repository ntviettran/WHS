using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.PLSP;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Repository.Repository.Coordinate;

namespace WHS.Repository.Repository.Transfer
{
    public class PLSPTransferRepository : TransferRepository<PLSPCoordinationDto, PLSPTransferDetailDto>
    {
        public PLSPTransferRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lấy ra danh sách plsp cần điều phối
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public override async Task<Response<List<PLSPCoordinationDto>>> GetTransferCoordinateByStatus(E_DispatchTransfer status)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                mo,
                                plsp_type,
                                plsp_code,
                                npl_color,
                                market_code,
                                size,
                                plsp_color,
                                quantity_to_received,
                                received_quantity,
                                remaining_quantity,
                                status,
                                dispatch_status
                             from vw_npl_plsp_detail
                             where dispatch_status = @status and status <> 3";

                List<PLSPCoordinationDto> ressult = (await conn.QueryAsync<PLSPCoordinationDto>(sql, new { status })).ToList();

                return Response<List<PLSPCoordinationDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PLSPCoordinationDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách chi tiết plsp đã điều phối theo id điều phối
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public override async Task<Response<List<PLSPTransferDetailDto>>> GetTransferDetail(int transferId)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"
                select id,
                        transfer_detail_id,
                        mo,
                        plsp_type,
                        plsp_code,
                        market_code,
                        npl_color,
                        size,
                        plsp_color,
                        quantity_to_received,
                        estimate_quantity,
                        received_quantity,
                        quantity_status
                from vw_npl_plsp_transfer_detail
                where transfer_id = @transferId";

                List<PLSPTransferDetailDto> ressult = (await conn.QueryAsync<PLSPTransferDetailDto>(sql, new { transferId })).ToList();

                return Response<List<PLSPTransferDetailDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PLSPTransferDetailDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách npl vải đã điều phối và cần điều phối theo id của plsp cần nhận
        /// </summary>
        /// <param name="idNplReceived"></param>
        /// <returns></returns>
        public override async Task<Response<List<PLSPCoordinationDto>>> GetCoordinationHistory(ReceiveHistorySearch search)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                const string sql = @"
                select 
                    plsp_type,
                    plsp_code,
                    npl_color,
                    market_code,
                    size,
                    plsp_color,
                    quantity_to_received,
                    received_quantity,
                    remaining_quantity,
                    status,
                    dispatch_status
                from vw_npl_plsp_detail
                where id_npl_received = @idNplReceived
                      and (@status = -1 or status = @status)
                      and (@dispatchStatus = -1 or dispatch_status = @dispatchStatus)";

                var param = new
                {
                    idNplReceived = search.ReceiveId,
                    status = search.Status,
                    dispatchStatus = search.DispatchStatus
                };

                var result = (await conn.QueryAsync<PLSPCoordinationDto>(sql, param)).ToList();

                return Response<List<PLSPCoordinationDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PLSPCoordinationDto>>.Show(ex);
            }
        }
    }
}
