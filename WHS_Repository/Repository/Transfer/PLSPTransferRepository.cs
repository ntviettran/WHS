using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.ErrorHandle;
using WHS.Core.Response;
using WHS.Repository.Repository.Coordinate;

namespace WHS.Repository.Repository.Transfer
{
    public class PLSPTransferRepository : TransferRepository<PLSPCoordinationDto, PLSPTransferDetailDto>
    {
        public PLSPTransferRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override async Task<Response<List<PLSPCoordinationDto>>> GetTransferCoordinateByStatus(E_DispatchTransfer status)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                id_npl_received as IdNplReceived,
                                mo,
                                plsp_type as PlspType,
                                plsp_code as PlspCode,
                                npl_color as NplColor,
                                quantity_to_received as QuantityToReceived,
                                quantity_received as QuantityReceived,
                                remaining_quantity as RemainingQuantity,
                                status,
                                dispatch_status as DispatchStatus
                             from vw_npl_plsp_transfer
                             where dispatch_status = @status";

                List<PLSPCoordinationDto> ressult = (await conn.QueryAsync<PLSPCoordinationDto>(sql, new { status })).ToList();

                return Response<List<PLSPCoordinationDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PLSPCoordinationDto>>.Show(ex);
            }
        }

        public override async Task<Response<List<PLSPTransferDetailDto>>> GetTransferDetail(int transferId)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                id_npl_received as IdNplReceived,
                                mo,
                                plsp_type as PlspType,
                                plsp_code as PlspCode,
                                market_code as MarketCode,
                                npl_color as NplColor,
                                size,
                                plsp_color as PlspColor,
                                quantity_to_received as QuantityToReceived,
                                estimate_quantity as EstimateQuantity,
                                quantity_received as QuantityReceived,
                                quantity_status as QuantityStatus
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
    }
}
