using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Enums;
using WHS.Repository.Interfaces;
using WHS.Service.Interface;

namespace WHS.Factory
{
    public class TransferFactory
    {
        public static ITransferService GetService(E_NPLType type)
        {
            if (Program.ServiceProvider == null) throw new NotImplementedException($"No service registered for type: {type}");

            return type switch
            {
                E_NPLType.FABRIC => Program.ServiceProvider!.GetRequiredService<ITransferService<FabricCoordinationDto, FabricTransferDetailDto>>(),
                E_NPLType.PLSP => Program.ServiceProvider!.GetRequiredService<ITransferService<PLSPCoordinationDto, PLSPTransferDetailDto>>(),
                E_NPLType.PLDG => Program.ServiceProvider!.GetRequiredService<ITransferService<PLDGCoordinationDto, PLDGTransferDetailDto>>(),
                _ => throw new NotImplementedException($"No service registered for type: {type}")
            };
        }
    }
}
