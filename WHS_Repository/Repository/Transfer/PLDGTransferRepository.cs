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
    public class PLDGTransferRepository : TransferRepository<PLDGCoordinationDto, PLDGTransferDetailDto>
    {
        public PLDGTransferRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override async Task<Response<List<PLDGCoordinationDto>>> GetTransferCoordinateByStatus(E_DispatchTransfer status)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                id_npl_received as IdNplReceived,
                                mo,
                                pldg_type as PldgType,
                                pack_code as PackCode,
                                color,
                                quantity_to_received as QuantityToReceived,
                                quantity_received as QuantityReceived,
                                remaining_quantity as RemainingQuantity,
                                status,
                                dispatch_status as DispatchStatus
                             from vw_npl_pldg_transfer
                             where dispatch_status = @status";

                List<PLDGCoordinationDto> ressult = (await conn.QueryAsync<PLDGCoordinationDto>(sql, new { status })).ToList();

                return Response<List<PLDGCoordinationDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<PLDGCoordinationDto>>.Show(ex);
            }
        }

        public override async Task<Response<List<PLDGTransferDetailDto>>> GetTransferDetail(int transferId)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                id_npl_received as IdNplReceived,
                                mo,
                                pldg_type as PldgType,
                                pack_code as PackCode,  
                                po_code as PoCode,
                                net_weight as NetWeight,
                                gross_weight as GrossWeight,
                                color,
                                pldg_size as PldgSize,
                                quantity_to_received as QuantityToReceived,
                                estimate_quantity as EstimateQuantity,
                                quantity_received as QuantityReceived,
                                quantity_status as QuantityStatus
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
    }
}
