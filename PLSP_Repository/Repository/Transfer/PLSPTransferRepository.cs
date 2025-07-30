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
using WHS.Core.Session;
using WHS.Repository.Repository.Coordinate;

namespace WHS.Repository.Repository.Transfer
{
    public class PLSPTransferRepository : TransferRepository<PlspCoordinationDto, PlspTransferDetailDto>
    {
        public PLSPTransferRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lấy ra danh sách plsp cần điều phối
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public override async Task<Response<List<PlspCoordinationDto>>> GetTransferCoordinateByStatus(E_DispatchTransfer status)
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
                             where dispatch_status = @status and status <> 3 and factory_id = @FactoryID";

                List<PlspCoordinationDto> ressult = (await conn.QueryAsync<PlspCoordinationDto>(sql, new { status, Session.CurrentUser.FactoryID })).ToList();

                return Response<List<PlspCoordinationDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PlspCoordinationDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách chi tiết plsp đã điều phối theo id điều phối
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public override async Task<Response<List<PlspTransferDetailDto>>> GetTransferDetail(int transferId)
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
                where transfer_id = @transferId and factory_id = @FactoryID";

                List<PlspTransferDetailDto> ressult = (await conn.QueryAsync<PlspTransferDetailDto>(sql, new { transferId, Session.CurrentUser.FactoryID })).ToList();

                return Response<List<PlspTransferDetailDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PlspTransferDetailDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách npl vải đã điều phối và cần điều phối theo id của plsp cần nhận
        /// </summary>
        /// <param name="idNplReceived"></param>
        /// <returns></returns>
        public override async Task<Response<List<PlspCoordinationDto>>> GetCoordinationHistory(ReceiveHistorySearch search)
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
                      and (@dispatchStatus = -1 or dispatch_status = @dispatchStatus)
                      and factory_id = @FactoryID";

                var param = new
                {
                    idNplReceived = search.ReceiveId,
                    status = search.Status,
                    dispatchStatus = search.DispatchStatus,
                    Session.CurrentUser.FactoryID
                };

                var result = (await conn.QueryAsync<PlspCoordinationDto>(sql, param)).ToList();

                return Response<List<PlspCoordinationDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PlspCoordinationDto>>.Show(ex);
            }
        }
    }
}
