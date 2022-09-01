using Authentication.Core.Abstractions.Authenticators;
using Microsoft.Extensions.DependencyInjection;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.Services.Navigation;
using MVVMEssentials.ViewModels;
using Ptichki.Data.Stores;
using Ptichki.Desktop.Factories;
using Ptichki.Domain.Abstractions.Repositories;
using Ptichki.Domain.Models;
using Ptichki.Presentation.ViewModels.Authorization;
using Ptichki.Presentation.ViewModels.Dto;
using Ptichki.Presentation.ViewModels.Hubs;
using Ptichki.Presentation.ViewModels.Listings;
using Ptichki.Presentation.ViewModels.Operations;
using Ptichki.Presentation.ViewModels.Service;

namespace Ptichki.Desktop.Registrators
{
    public static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton(s => new HomeViewModel(ServiceViewModelFactories.CreateLoginNavigationService(s)))

            .AddTransient(s => new AccountViewModel(
                s.GetRequiredService<IAuthenticator>(),
                ServiceViewModelFactories.CreateHomeNavigationService(s)))

            .AddTransient(ServiceViewModelFactories.CreateLoginViewModel)

            .AddTransient(s => new RegisterViewModel(s.GetRequiredService<IAuthenticator>(),
                                                              s.GetRequiredService<INavigationService>(),
                                                              s.GetRequiredService<INavigationService>()
                                                             ))

            .AddSingleton(s => new HubNavigationDto(
                                                    HubNavigationFactories.CreateBatchesListingViewModel(s),
                                                    HubNavigationFactories.CreateBirdsListingViewModel(s),
                                                    HubNavigationFactories.CreateBirdsTypesListingViewModel(s),
                                                    HubNavigationFactories.CreateCustomersListingViewModel(s),
                                                    HubNavigationFactories.CreateDepartmentsListingViewModel(s),
                                                    HubNavigationFactories.CreateEmployeesInDepartmentsListingViewModel(s),
                                                    HubNavigationFactories.CreateEmployeesListingViewModel(s),
                                                    HubNavigationFactories.CreateEquipmentListingViewModel(s),
                                                    HubNavigationFactories.CreateOrdersListingViewModel(s),
                                                    HubNavigationFactories.CreateParametersListingViewModel(s),
                                                    HubNavigationFactories.CreateProcessesListingViewModel(s),
                                                    HubNavigationFactories.CreateProcessesTechnologyListingViewModel(s),
                                                    HubNavigationFactories.CreateProductCatalogListingViewModel(s),
                                                    HubNavigationFactories.CreateStagesListingViewModel(s),
                                                    HubNavigationFactories.CreateWorksListingViewModel(s)
                                                   ))
            .AddSingleton(s => new HubViewModel(s.GetRequiredService<HubNavigationDto>()))

            .AddSingleton(s => new PeopleListingViewModel(s.GetRequiredService<PeopleStore>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddPeopleNavigationService(s)));

        public static IServiceCollection AddAddingViewModels(this IServiceCollection services) => services
                
            .AddTransient(s => new AddingBatchViewModel(s.GetRequiredService<GenericStore<Batch>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingBirdsTypesViewModel(s.GetRequiredService<GenericStore<BirdType>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingBirdsViewModel(s.GetRequiredService<GenericStore<Bird>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingCustomersViewModel(s.GetRequiredService<GenericStore<Customer>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingDepartmentsViewModel(s.GetRequiredService<GenericStore<Department>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingEmployeesInDepartmentsViewModel())

            .AddTransient(s => new AddingEmployeesViewModel(s.GetRequiredService<GenericStore<Employee>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingOrdersViewModel(s.GetRequiredService<GenericStore<Order>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingParametersViewModel(s.GetRequiredService<GenericStore<Parameter>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingProcessesViewModel(s.GetRequiredService<GenericStore<Process>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingProcessTechnologiesViewModel())

            .AddTransient(s => new AddingProductCatalogViewModel(s.GetRequiredService<GenericStore<ProductCatalog>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingStagesViewModel(s.GetRequiredService<GenericStore<Stage>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingWorksViewModel(s.GetRequiredService<GenericStore<Work>>(),
                s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingPersonViewModel(s.GetRequiredService<PeopleStore>(),
                                                                  s.GetRequiredService<CloseModalNavigationService>()))

            .AddTransient(s => new AddingPeopleViewModel(s.GetRequiredService<PeopleStore>(),
                                                                  s.GetRequiredService<CloseModalNavigationService>()));

        public static IServiceCollection AddListingViewModels(this IServiceCollection services) => services

            .AddSingleton(s => new BatchesListingViewModel(s.GetRequiredService<GenericStore<Batch>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddBatchesNavigationService(s)))

            .AddSingleton(s => new BirdsTypesListingViewModel(s.GetRequiredService<GenericStore<BirdType>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddBirdsTypesNavigationService(s)))

            .AddSingleton(s => new BirdsListingViewModel(s.GetRequiredService<GenericStore<Bird>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddBirdsNavigationService(s)))

            .AddSingleton(s => new CustomersListingViewModel(s.GetRequiredService<GenericStore<Customer>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddCustomersNavigationService(s)))

            .AddSingleton(s => new DepartmentsListingViewModel(s.GetRequiredService<GenericStore<Department>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddDepartmentsNavigationService(s)))

            .AddSingleton(s => new EmployeesInDepartmentsListingViewModel(s.GetRequiredService<GenericStore<EmployeesInDepartments>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddEmployeesInDepartmentsNavigationService(s)))

            .AddSingleton(s => new EmployeesListingViewModel(s.GetRequiredService<GenericStore<Employee>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddEmployeesNavigationService(s)))

            .AddSingleton(s => new EquipmentListingViewModel(s.GetRequiredService<GenericStore<Equipment>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddEquipmentNavigationService(s)))

            .AddSingleton(s => new OrdersListingViewModel(s.GetRequiredService<GenericStore<Order>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddOrdersNavigationService(s)))

            .AddSingleton(s => new ParametersListingViewModel(s.GetRequiredService<GenericStore<Parameter>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddParametersNavigationService(s)))

            .AddSingleton(s => new ProcessesTechnologiesListingViewModel(s.GetRequiredService<GenericStore<ProcessTechnology>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddProcessTechnologiesNavigationService(s)))

            .AddSingleton(s => new ProductCatalogListingViewModel(s.GetRequiredService<GenericStore<ProductCatalog>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddProductCatalogNavigationService(s)))

            .AddSingleton(s => new StagesListingViewModel(s.GetRequiredService<GenericStore<Stage>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddStagesNavigationService(s)))

            .AddSingleton(s => new WorksListingViewModel(s.GetRequiredService<IRepository<Work>>(),
                s.GetRequiredService<GenericStore<Work>>(),
                NavigationServicesFactories.CreateAddPersonNavigationService(s),
                NavigationServicesFactories.CreateAddWorksNavigationService(s)));

        public static IServiceCollection AddNavigationBarViewModel(this IServiceCollection services) => services
            .AddTransient(ServiceViewModelFactories.CreateNavigationBarViewModel);
        public static IServiceCollection AddMainViewModel(this IServiceCollection services) => 
            services.AddSingleton<MainViewModel>();
    }

}
