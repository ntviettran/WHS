using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Receive;
using WHS.Core.Dto.Transfer;
using WHS.Factory;
using WHS.Forms;
using WHS.Pages.Receive;
using WHS.Pages.Transfer;
using WHS.Popup;
using WHS.Popup.Transfer;
using WHS.Repository.Interfaces;
using WHS.Repository.Repository.Coordinate;
using WHS.Repository.Repository.Receive;
using WHS.Repository.Repository.Transfer;
using WHS.Repository.Repository.User;
using WHS.Repository.Repository.Vehicle;
using WHS.Service.Interface;
using WHS.Service.Services;
using WHS.Service.Services.Coordinate;
using WHS.Service.Services.Receive;
using WHS.Service.Services.Transfer;
using WHS.Service.Services.Vehicle;

namespace WHS
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            //LoginForm loginForm = ServiceProvider.GetRequiredService<LoginForm>();
            //Application.Run(loginForm);

            MainForm mainForm = new MainForm();
            Application.Run(mainForm);

            //TransferDetail mainForm = new TransferDetail();
            //Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IReceiveRepository<,>), typeof(ReceiveRepository<,>));
            services.AddScoped<IReceiveRepository<FabricDto, FabricDetailDto>, FabricReceiveRepository>();
            services.AddScoped<IReceiveRepository<PldgDto, PldgDetailDto>, PldgReceiveRepository>();
            services.AddScoped<IReceiveRepository<PlspDto, PlspDetailDto>, PlspReceiveRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleService, VehicleService>();

            services.AddScoped<ITransferRepository, BaseTransferRepository>();
            services.AddScoped<ITransferService, BaseTransferService>();
            services.AddScoped<ITransferRepository<FabricCoordinationDto, FabricTransferDetailDto>, FabricTransferRepository>();
            services.AddScoped<ITransferRepository<PLSPCoordinationDto, PLSPTransferDetailDto>, PLSPTransferRepository>();
            services.AddScoped<ITransferRepository<PLDGCoordinationDto, PLDGTransferDetailDto>, PLDGTransferRepository>();
            services.AddScoped(typeof(ITransferService<,>), typeof(TransferService<,>));

            services.AddScoped<IReceiveService<FabricDto, FabricDetailDto>, ReceiveService<FabricDto, FabricDetailDto>>();
            services.AddScoped<IReceiveService<PlspDto, PlspDetailDto>, ReceiveService<PlspDto, PlspDetailDto>>();
            services.AddScoped<IReceiveService<PldgDto, PldgDetailDto>, ReceiveService<PldgDto, PldgDetailDto>>();

            services.AddTransient<LoginForm>();
            services.AddTransient<DetailReceive>();
            services.AddTransient<TransferNPLPage>();

            services.AddTransient<FabricPopup>();
            services.AddTransient<PLSPPopup>();
            services.AddTransient<PLDGPopup>();
            services.AddTransient<AddTransferPopup>();
            services.AddTransient<AddTransferDetailPopup>();
            services.AddTransient<VehiclePopup>();
            services.AddTransient<AddVehiclePopup>();
            services.AddTransient<TransferDetail>();
        }
    }
}