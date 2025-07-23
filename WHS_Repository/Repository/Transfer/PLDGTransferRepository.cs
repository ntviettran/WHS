using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.PLDG;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Repository.Repository.Coordinate;

namespace WHS.Repository.Repository.Transfer
{
    public class PLDGTransferRepository : TransferRepository<PLDGCoordinationDto, PLDGTransferDetailDto>
    {
        public PLDGTransferRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lấy ra danh sách pldg cần điều phối
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public override async Task<Response<List<PLDGCoordinationDto>>> GetTransferCoordinateByStatus(E_DispatchTransfer status)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                mo,
                                pldg_type,
                                pldg_code,
                                po_code,
                                color,
                                pldg_size,
                                net_weight,
                                gross_weight,
                                quantity_to_received,
                                received_quantity,
                                remaining_quantity,
                                status,
                                dispatch_status
                             from vw_npl_pldg_detail
                             where dispatch_status = @status";

                List<PLDGCoordinationDto> ressult = (await conn.QueryAsync<PLDGCoordinationDto>(sql, new { status })).ToList();

                return Response<List<PLDGCoordinationDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PLDGCoordinationDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách chi tiết điều chuyển theo id của điều chuyển
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public override async Task<Response<List<PLDGTransferDetailDto>>> GetTransferDetail(int transferId)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            try
            {
                string sql = @"select id,
                                transfer_detail_id,
                                mo,
                                pldg_type,
                                pldg_code,
                                po_code,
                                color,
                                pldg_size,
                                size_unit,        
                                net_weight,
                                gross_weight, 
                                quantity_to_received,
                                estimate_quantity,
                                received_quantity,
                                quantity_status
                             from vw_npl_pldg_transfer_detail
                             where transfer_id = @transferId";

                List<PLDGTransferDetailDto> ressult = (await conn.QueryAsync<PLDGTransferDetailDto>(sql, new { transferId })).ToList();

                return Response<List<PLDGTransferDetailDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PLDGTransferDetailDto>>.Show(ex);
            }
        }

        /// <summary>
        /// Lấy ra danh sách npl vải đã điều phối và cần điều phối theo id của pldg cần nhận
        /// </summary>
        /// <param name="idNplReceived"></param>
        /// <returns></returns>
        public override async Task<Response<List<PLDGCoordinationDto>>> GetCoordinationHistory(ReceiveHistorySearch search)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                const string sql = @"
                select 
                    pldg_type,
                    pack_code,
                    po_code,
                    quantity_per_carton,
                    net_weight,
                    gross_weight,
                    color,
                    pldg_weight,
                    weight_unit,
                    pldg_size,
                    size_unit,
                    pldg_weight,        
                    weight_unit,   
                    quantity_to_received,
                    quantity_received,
                    remaining_quantity,
                    status,
                    dispatch_status
                from vw_npl_pldg_detail
                where id_npl_received = @idNplReceived
                      and (@status = -1 or status = @status)
                      and (@dispatchStatus = -1 or dispatch_status = @dispatchStatus)";

                var param = new
                {
                    idNplReceived = search.ReceiveId,
                    status = search.Status,
                    dispatchStatus = search.DispatchStatus
                };

                var result = (await conn.QueryAsync<PLDGCoordinationDto>(sql, param)).ToList();

                return Response<List<PLDGCoordinationDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PLDGCoordinationDto>>.Show(ex);
            }
        }
    }
}
