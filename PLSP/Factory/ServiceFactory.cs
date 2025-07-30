using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PLSP.Service.Interface;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Enums;
using WHS.Service.Interface;

namespace WHS.Factory
{


    public class ServiceFactory
    {
        public static IInventoryService GetInventoryService()
        {
            if (Program.ServiceProvider == null) throw new NotImplementedException($"No service registered");

            return Program.ServiceProvider!.GetRequiredService<IInventoryService>();
        }

        public static IInventoryService<T, D> GetInventoryService<T, D>() 
            where T : class
            where D : class
        {
            if (Program.ServiceProvider == null) throw new NotImplementedException($"No service registered");

            return Program.ServiceProvider!.GetRequiredService<IInventoryService<T, D>>();
        }

        public static IReceiveService<T, D> GetReceiveService<T,D>()
            where T : class
            where D : class
        {
            if (Program.ServiceProvider == null) throw new NotImplementedException($"No service registered");

            return Program.ServiceProvider!.GetRequiredService<IReceiveService<T, D>>();
        }

        public static ITransactionService GetTransactionService()
        {
            if (Program.ServiceProvider == null) throw new NotImplementedException($"No service registered");

            return Program.ServiceProvider!.GetRequiredService<ITransactionService>();
        }

        public static ITransactionService<T> GetTransactionService<T>()
            where T : class
        {
            if (Program.ServiceProvider == null) throw new NotImplementedException($"No service registered");

            return Program.ServiceProvider!.GetRequiredService<ITransactionService<T>>();
        }

        public static IUserService GetUserService()
        {
            if (Program.ServiceProvider == null) throw new NotImplementedException($"No service registered");

            return Program.ServiceProvider!.GetRequiredService<IUserService>();
        }
    }
}
