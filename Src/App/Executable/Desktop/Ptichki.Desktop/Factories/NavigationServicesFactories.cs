using System;
using Microsoft.Extensions.DependencyInjection;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.Services.Navigation;
using MVVMEssentials.Stores.Navigation;
using Ptichki.Presentation.ViewModels.Operations;

namespace Ptichki.Desktop.Factories
{
    public static class NavigationServicesFactories
    {
        internal static INavigationService CreateAddBatchesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingBatchViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingBatchViewModel>()
            );

        internal static INavigationService CreateAddBirdsTypesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingBirdsTypesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingBirdsTypesViewModel>()
            );

        internal static INavigationService CreateAddBirdsNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingBirdsViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingBirdsViewModel>()
            );

        internal static INavigationService CreateAddCustomersNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingCustomersViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingCustomersViewModel>()
            );

        internal static INavigationService CreateAddDepartmentsNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingDepartmentsViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingDepartmentsViewModel>()
            );

        internal static INavigationService CreateAddEmployeesInDepartmentsNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingEmployeesInDepartmentsViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingEmployeesInDepartmentsViewModel>()
            );

        internal static INavigationService CreateAddEmployeesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingEmployeesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingEmployeesViewModel>()
            );

        internal static INavigationService CreateAddEquipmentNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingEquipmentViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingEquipmentViewModel>()
            );

        internal static INavigationService CreateAddOrdersNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingOrdersViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingOrdersViewModel>()
            );

        internal static INavigationService CreateAddParametersNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingParametersViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingParametersViewModel>()
            );

        internal static INavigationService CreateAddProcessesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingProcessesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingProcessesViewModel>()
            );

        internal static INavigationService CreateAddProcessTechnologiesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingProcessTechnologiesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingProcessTechnologiesViewModel>()
            );

        internal static INavigationService CreateAddProductCatalogNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingProductCatalogViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingProductCatalogViewModel>()
            );

        internal static INavigationService CreateAddStagesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingStagesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingStagesViewModel>()
            );

        internal static INavigationService CreateAddWorksNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingWorksViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingWorksViewModel>()
            );

        internal static INavigationService CreateAddPeopleNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingPeopleViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingPeopleViewModel>()
            );

        internal static INavigationService CreateAddPersonNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingPersonViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingPersonViewModel>()
            );
    }
}
