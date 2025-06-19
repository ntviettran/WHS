using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WHS.Forms;
using WHS.Pages.Receive;
using WHS.Repository.Interfaces;
using WHS.Repository.Repository;
using WHS.Service.Interface;
using WHS.Service.Services;

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
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddTransient<LoginForm>();
            services.AddTransient<DetailReceive>();
        }
    }
}