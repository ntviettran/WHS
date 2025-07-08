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

namespace WHS.Repository.Repository.Coordinate
{
    public class FabricTransferRepository : TransferRepository<FabricCoordinationDto, FabricTransferDetailDto>
    {
        public FabricTransferRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override async Task<Response<List<FabricCoordinationDto>>> GetTransferCoordinateByStatus(E_DispatchTransfer status)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                id_npl_received as IdNplReceived,
                                mo,
                                style,
                                color,
                                fabric_type as FabricType,
                                batch,
                                fabric_length as FabricLength,
                                fabric_weight as FabricWeight,
                                length_received as LengthReceived,
                                weight_received as WeightReceived,
                                quantity_to_received as QuantityToReceived,
                                quantity_received as QuantityReceived,
                                remaining_quantity as RemainingQuantity,
                                status,
                                dispatch_status as DispatchStatus
                             from vw_npl_fabric_transfer
                             where dispatch_status = @status";

                List<FabricCoordinationDto> result = (await conn.QueryAsync<FabricCoordinationDto>(sql, new { status })).ToList();

                return Response<List<FabricCoordinationDto>>.Success(result);
            }
            catch (Exception ex) { 
                return ErrorHandler<List<FabricCoordinationDto>>.Show(ex);
            }
        }

        public override async Task<Response<List<FabricTransferDetailDto>>> GetTransferDetail(int transferId)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();

            try
            {
                string sql = @"select id,
                                id_npl_received as IdNplReceived,
                                mo,
                                style,
                                color,
                                fabric_type as FabricType,
                                batch,
                                fabric_length as FabricLength,
                                fabric_weight as FabricWeight,
                                roll_width as RollWidth,
                                fabric_number as FabricNumber,
                                length_received as LengthReceived,
                                weight_received as WeightReceived,
                                quantity_to_received as QuantityToReceived,
                                estimate_quantity as EstimateQuantity,
                                quantity_received as QuantityReceived,
                                quantity_status as QuantityStatus,
                                length_status as LengthStatus,
                                weight_status as WeightStatus
                             from vw_npl_fabric_transfer_detail
                             where transfer_id = @transferId";

                List<FabricTransferDetailDto> ressult = (await conn.QueryAsync<FabricTransferDetailDto>(sql, new { transferId })).ToList();

                return Response<List<FabricTransferDetailDto>>.Success(ressult);
            }
            catch (Exception ex)
            {
                return ErrorHandler<List<FabricTransferDetailDto>>.Show(ex);
            }
        }
    }
}
