using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services.Abstract;
using Ptichki.Data.IoC;
using Ptichki.Desktop.Registrators;

namespace Ptichki.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private static IHost _host;
        public static IHost Host => 
            _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public IServiceProvider ServiceProvider => Host.Services;

        public App()
        {
            //_authenticationContainer = new();
            //_container = new();
        }

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("Database"))
            .AddStores()
            .AddAuthServices()
            .AddNavigationServices()
            .AddViewModels()
            .AddAddingViewModels()
            .AddListingViewModels()
            .AddNavigationBarViewModel()
            .AddMainViewModel()
            .AddWindows();
       

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            //INavigationService initialNavigationService =
            //    _container.ServiceProvider.GetRequiredService<LayoutNavigationService<HomeViewModel>>();
            //initialNavigationService.Navigate();

            await host.StartAsync();


            using (var scope = ServiceProvider.CreateScope())
            {
                await scope.ServiceProvider
                    .GetRequiredService<DbInitializer>()
                    .InitializeAsync();
            }
            //INavigationService homeNavigationService = host.Services.GetRequiredService<LayoutNavigationService<HomeViewModel>>();
            //homeNavigationService.Navigate();

            INavigationService initialNavigationService = host.Services.GetService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = host.Services.GetService<MainWindow>();
            MainWindow?.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
