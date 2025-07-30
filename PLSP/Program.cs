using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PLSP.Core.Dto.PLSP;
using PLSP.Pages;
using PLSP.Pages.Warehouse;
using PLSP.Repository.Interfaces;
using PLSP.Repository.Repository.Inventory;
using PLSP.Repository.Repository.Transaction;
using PLSP.Service.Interface;
using PLSP.Service.Services.Inventory;
using PLSP.Service.Services.Transaction;
using PLSP.Service.Services.User;
using System.Configuration;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Transfer;
using WHS.Factory;
using WHS.Forms;
using WHS.Pages;
using WHS.Pages.Receive;
using WHS.Pages.Transfer;
using WHS.Popup;
using WHS.Popup.PO;
using WHS.Popup.Transfer;
using WHS.Popup.Vehicle;
using WHS.Repository.Interfaces;
using WHS.Repository.Repository.Coordinate;
using WHS.Repository.Repository.PO;
using WHS.Repository.Repository.Receive;
using WHS.Repository.Repository.Transfer;
using WHS.Repository.Repository.User;
using WHS.Repository.Repository.Vehicle;
using WHS.Service.Interface;
using WHS.Service.Services.Coordinate;
using WHS.Service.Services.PO;
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

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var configuration = ServiceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (!CheckDatabaseConnection(connectionString!))
            {
                MessageBox.Show("Không thể kết nối đến CSDL. Vui lòng kiểm tra hoặc thử lại sau.",
                                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return;
            }

            ApplicationConfiguration.Initialize();

            LoginForm loginForm = ServiceProvider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);

            //Application.Run(new MainForm());
        }

        static bool CheckDatabaseConnection(string connectionString)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
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
            services.AddScoped<IReceiveRepository<FabricDto, FabricReceivedDto>, FabricReceiveRepository>();
            services.AddScoped<IReceiveRepository<PldgDto, PldgReceivedDto>, PldgReceiveRepository>();
            services.AddScoped<IReceiveRepository<PlspDto, PlspReceivedDto>, PlspReceiveRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleService, VehicleService>();

            services.AddScoped<IPORepository, PORepository>();
            services.AddScoped<IPOService, PoService>();

            services.AddScoped<ITransferRepository, BaseTransferRepository>();
            services.AddScoped<ITransferService, BaseTransferService>();
            services.AddScoped<ITransferRepository<FabricCoordinationDto, FabricTransferDetailDto>, FabricTransferRepository>();
            services.AddScoped<ITransferRepository<PlspCoordinationDto, PlspTransferDetailDto>, PLSPTransferRepository>();
            services.AddScoped<ITransferRepository<PLDGCoordinationDto, PLDGTransferDetailDto>, PLDGTransferRepository>();
            services.AddScoped(typeof(ITransferService<,>), typeof(TransferService<,>));

            services.AddScoped<IInventoryService, BaseInventoryService>();
            services.AddScoped<IInventoryRepository<PlspInventoryDto, PlspInventoryLocationDto>, PLSPInventoryRepository>();
            services.AddScoped(typeof(IInventoryService<,>), typeof(InventoryService<,>));

            services.AddScoped<ITransactionRepository, BaseTransactionRepository>();
            services.AddScoped<ITransactionService, BaseTransactionService>();
            services.AddScoped(typeof(ITransactionRepository<>), typeof(TransactionRepository<>));
            services.AddScoped(typeof(ITransactionService<>), typeof(TransactionService<>));

            services.AddScoped<IReceiveService<FabricDto, FabricReceivedDto>, ReceiveService<FabricDto, FabricReceivedDto>>();
            services.AddScoped<IReceiveService<PlspDto, PlspReceivedDto>, ReceiveService<PlspDto, PlspReceivedDto>>();
            services.AddScoped<IReceiveService<PldgDto, PldgReceivedDto>, ReceiveService<PldgDto, PldgReceivedDto>>();

            services.AddTransient<LoginForm>();
            services.AddTransient<GroupDetailReceive>();
            services.AddTransient<DetailReceivePage>();
            services.AddTransient<CoordinateNPLPage>();
            services.AddTransient<POPage>();
            services.AddTransient<TotalInventoryPage>();
            services.AddTransient<DetailInventoryPage>();
            services.AddTransient<QRInventoryPage>();
            services.AddTransient<ExportInventoryPage>();
            services.AddTransient<HistoryTransactionPage>();
            services.AddTransient<WorkerPage>();
            services.AddTransient<QRLocation>();

            services.AddTransient<FabricPopup>();
            services.AddTransient<PLSPPopup>();
            services.AddTransient<PLDGPopup>();
            services.AddTransient<AddTransferPopup>();
            services.AddTransient<AddTransferDetailPopup>();
            services.AddTransient<VehiclePopup>();
            services.AddTransient<AddVehiclePopup>();
            services.AddTransient<TransferDetail>();
            services.AddTransient<PoPopup>();
            services.AddTransient<VehicleTransferPopup>();
        }
    }
}