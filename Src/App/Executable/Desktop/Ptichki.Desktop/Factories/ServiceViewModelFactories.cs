using System;
using Authentication.Core.Abstractions.Authenticators;
using Microsoft.Extensions.DependencyInjection;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.Services.Navigation;
using MVVMEssentials.Stores.Navigation;
using Ptichki.Desktop.Services.Navigation;
using Ptichki.Presentation.ViewModels.Authorization;
using Ptichki.Presentation.ViewModels.Hubs;
using Ptichki.Presentation.ViewModels.Listings;
using Ptichki.Presentation.ViewModels.Navigation;
using Ptichki.Presentation.ViewModels.Service;

namespace Ptichki.Desktop.Factories
{
    public static class ServiceViewModelFactories
    {
        internal static NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider) =>
            new(serviceProvider.GetRequiredService<IAuthenticator>(),
                CreateHomeNavigationService(serviceProvider),
                CreateAccountNavigationService(serviceProvider),
                CreatePeopleListingNavigationService(serviceProvider),
                CreateHubViewModelNavigationService(serviceProvider)
            );

        private static INavigationService CreateHubViewModelNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<HubViewModel>(
                                                      serviceProvider.GetRequiredService<NavigationStore>(),
                                                      () => serviceProvider.GetRequiredService<HubViewModel>(),
                                                      () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                     );
        private static INavigationService CreatePeopleListingNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<PeopleListingViewModel>(
                                                                serviceProvider.GetRequiredService<NavigationStore>(),
                                                                () => serviceProvider.GetRequiredService<PeopleListingViewModel>(),
                                                                () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                                );

        internal static LayoutNavigationService<HomeViewModel> CreateHomeNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<HomeViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<HomeViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        private static INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<AccountViewModel>(
                                                          serviceProvider.GetRequiredService<NavigationStore>(),
                                                          () => serviceProvider.GetRequiredService<AccountViewModel>(),
                                                          () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                          );

        internal static INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<LoginViewModel>(
                                                        serviceProvider.GetRequiredService<ModalNavigationStore>(),
                                                        () => serviceProvider.GetRequiredService<LoginViewModel>()
                                                      );

        private static INavigationService CreateRegistrationNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<RegisterViewModel>(
                                                          serviceProvider.GetRequiredService<ModalNavigationStore>(),
                                                          () => serviceProvider.GetRequiredService<RegisterViewModel>()
                                                         );

        internal static LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService compositeNavigationService = new CompositeNavigationService(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateAccountNavigationService(serviceProvider)
                );

            return new LoginViewModel(
                                      serviceProvider.GetRequiredService<IAuthenticator>(),
                                      compositeNavigationService,
                                      CreateRegistrationNavigationService(serviceProvider)
                                     );
        }
    }
}
