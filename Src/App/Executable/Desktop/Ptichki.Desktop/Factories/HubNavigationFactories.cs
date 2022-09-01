using System;
using Microsoft.Extensions.DependencyInjection;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.Stores.Navigation;
using Ptichki.Desktop.Services.Navigation;
using Ptichki.Presentation.ViewModels.Listings;
using Ptichki.Presentation.ViewModels.Navigation;

namespace Ptichki.Desktop.Factories
{
    public static class HubNavigationFactories
    {
        internal static INavigationService CreateBatchesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<BatchesListingViewModel>(
                                                                 serviceProvider.GetRequiredService<NavigationStore>(),
                                                                 () => serviceProvider.GetRequiredService<BatchesListingViewModel>(),
                                                                 () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                                 );

        internal static INavigationService CreateBirdsListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<BirdsListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<BirdsListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateBirdsTypesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<BirdsTypesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<BirdsTypesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateCustomersListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<CustomersListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<CustomersListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateDepartmentsListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<DepartmentsListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<DepartmentsListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateEmployeesInDepartmentsListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<EmployeesInDepartmentsListingViewModel>(
                                                                                serviceProvider.GetRequiredService<NavigationStore>(),
                                                                                () => serviceProvider.GetRequiredService<EmployeesInDepartmentsListingViewModel>(),
                                                                                () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                                                );

        internal static INavigationService CreateEmployeesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<EmployeesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<EmployeesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateEquipmentListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<EquipmentListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<EquipmentListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateOrdersListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<OrdersListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<OrdersListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateParametersListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<ParametersListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ParametersListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
            );

        internal static INavigationService CreateProcessesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<ProcessesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<ProcessesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateProcessesTechnologyListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<ProcessesTechnologiesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<ProcessesTechnologiesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateProductCatalogListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<ProductCatalogListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<ProductCatalogListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateStagesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<StagesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<StagesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        internal static INavigationService CreateWorksListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<WorksListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<WorksListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
    }
}
