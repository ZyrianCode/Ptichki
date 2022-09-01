using Microsoft.Extensions.DependencyInjection;
using MVVMEssentials.Services.Navigation;
using Ptichki.Desktop.Factories;
using Ptichki.Desktop.Services.Navigation;
using Ptichki.Presentation.ViewModels.Service;

namespace Ptichki.Desktop.Registrators
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddNavigationServices(this IServiceCollection services) => services
            .AddSingleton<CloseModalNavigationService>()
            .AddSingleton<LayoutNavigationService<HomeViewModel>>(ServiceViewModelFactories.CreateHomeNavigationService)
            .AddTransient(ServiceViewModelFactories.CreateLoginNavigationService);

    }
}
