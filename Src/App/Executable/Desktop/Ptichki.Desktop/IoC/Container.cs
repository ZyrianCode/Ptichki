using System;
using Authentication.Core.Abstractions.Authenticators;
using Microsoft.Extensions.DependencyInjection;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.Services.Navigation;
using MVVMEssentials.Stores.Navigation;
using MVVMEssentials.ViewModels;
using Ptichki.Data.Stores;
using Ptichki.Desktop.Services.Navigation;
using Ptichki.Domain.Abstractions.Repositories;
using Ptichki.Domain.Models;
using Ptichki.Presentation.ViewModels.Authorization;
using Ptichki.Presentation.ViewModels.Dto;
using Ptichki.Presentation.ViewModels.Hubs;
using Ptichki.Presentation.ViewModels.Listings;
using Ptichki.Presentation.ViewModels.Navigation;
using Ptichki.Presentation.ViewModels.Operations;
using Ptichki.Presentation.ViewModels.Service;

namespace Ptichki.Desktop.IoC
{
    public class Container
    {
        private AuthenticationContainer _authenticationContainer;
        private IServiceProvider _aCSP; 
        
        private readonly IServiceCollection _services;
        private IServiceProvider _serviceProvider;

        public IServiceProvider ServiceProvider => _serviceProvider;

        public Container()
        {
            _services = new ServiceCollection();
        }

        public void Start(AuthenticationContainer authenticationContainer)
        {
            _authenticationContainer = authenticationContainer;
            _aCSP = _authenticationContainer.ServiceProvider;

            AddStores();
            AddServices();
            AddViewModels();
            AddWindows();

            _serviceProvider = _services.BuildServiceProvider();
        }

        private void AddStores()
        {
            _services.AddSingleton<PeopleStore>();
            _services.AddSingleton<GenericStore<Batch>>();
            _services.AddSingleton<GenericStore<Bird>>();
            _services.AddSingleton<GenericStore<BirdType>>();   
            _services.AddSingleton<GenericStore<Customer>>();   
            _services.AddSingleton<GenericStore<Department>>();   
            _services.AddSingleton<GenericStore<EmployeesInDepartments>>();   
            _services.AddSingleton<GenericStore<Employee>>();   
            _services.AddSingleton<GenericStore<Equipment>>();   
            _services.AddSingleton<GenericStore<Order>>();
            _services.AddSingleton<GenericStore<Parameter>>();
            _services.AddSingleton<GenericStore<Process>>();
            _services.AddSingleton<GenericStore<ProcessTechnology>>();
            _services.AddSingleton<GenericStore<ProductCatalog>>();
            _services.AddSingleton<GenericStore<Stage>>();
            _services.AddSingleton<GenericStore<Work>>();
            
            _services.AddSingleton<NavigationStore>();
            _services.AddSingleton<ModalNavigationStore>();
        }

        private void AddDatabase()
        {

        }
        private void AddServices()
        {
            _services.AddSingleton<CloseModalNavigationService>();
            _services.AddSingleton<LayoutNavigationService<HomeViewModel>>(CreateHomeNavigationService);
            _services.AddTransient(CreateLoginNavigationService);
        }

        private void AddViewModels()
        {
           
            _services.AddSingleton(s => new HomeViewModel(CreateLoginNavigationService(s)));
            
            
            _services.AddTransient(s => new AccountViewModel(
                _aCSP.GetRequiredService<IAuthenticator>(),
                CreateHomeNavigationService(s)));

            _services.AddTransient(CreateLoginViewModel);

            _services.AddTransient(s => new RegisterViewModel(_aCSP.GetRequiredService<IAuthenticator>(),
                                                              s.GetRequiredService<INavigationService>(),
                                                              s.GetRequiredService<INavigationService>()
                                                             ));

            _services.AddSingleton(s => new HubNavigationDto(
                                                             CreateBatchesListingViewModel(s),
                                                             CreateBirdsListingViewModel(s),
                                                             CreateBirdsTypesListingViewModel(s),
                                                             CreateCustomersListingViewModel(s),
                                                             CreateDepartmentsListingViewModel(s),
                                                             CreateEmployeesInDepartmentsListingViewModel(s),
                                                             CreateEmployeesListingViewModel(s),
                                                             CreateEquipmentListingViewModel(s),
                                                             CreateOrdersListingViewModel(s),
                                                             CreateParametersListingViewModel(s),
                                                             CreateProcessesListingViewModel(s),
                                                             CreateProcessesTechnologyListingViewModel(s),
                                                             CreateProductCatalogListingViewModel(s),
                                                             CreateStagesListingViewModel(s),
                                                             CreateWorksListingViewModel(s)
                                                             ));

            _services.AddSingleton(s => new HubViewModel(s.GetRequiredService<HubNavigationDto>()));

            _services.AddSingleton(s => new PeopleListingViewModel(s.GetRequiredService<PeopleStore>(),
                                                                   CreateAddPersonNavigationService(s),
                                                                   CreateAddPeopleNavigationService(s)));
            #region DbListingsViewModels

            _services.AddSingleton(s => new BatchesListingViewModel(s.GetRequiredService<GenericStore<Batch>>(),
                CreateAddPersonNavigationService(s),
                CreateAddBatchesNavigationService(s)));

            _services.AddSingleton(s => new BirdsTypesListingViewModel(s.GetRequiredService<GenericStore<BirdType>>(),
                CreateAddPersonNavigationService(s),
                CreateAddBirdsTypesNavigationService(s)));

            _services.AddSingleton(s => new BirdsListingViewModel(s.GetRequiredService<GenericStore<Bird>>(),
                CreateAddPersonNavigationService(s),
                CreateAddBirdsNavigationService(s)));

            _services.AddSingleton(s => new CustomersListingViewModel(s.GetRequiredService<GenericStore<Customer>>(),
                CreateAddPersonNavigationService(s),
                CreateAddCustomersNavigationService(s)));

            _services.AddSingleton(s => new DepartmentsListingViewModel(s.GetRequiredService<GenericStore<Department>>(),
                CreateAddPersonNavigationService(s),
                CreateAddDepartmentsNavigationService(s)));

            _services.AddSingleton(s => new EmployeesInDepartmentsListingViewModel(s.GetRequiredService<GenericStore<EmployeesInDepartments>>(),
                CreateAddPersonNavigationService(s),
                CreateAddEmployeesInDepartmentsNavigationService(s)));

            _services.AddSingleton(s => new EmployeesListingViewModel(s.GetRequiredService<GenericStore<Employee>>(),
                CreateAddPersonNavigationService(s),
                CreateAddEmployeesNavigationService(s)));

            _services.AddSingleton(s => new EquipmentListingViewModel(s.GetRequiredService<GenericStore<Equipment>>(),
                CreateAddPersonNavigationService(s),
                CreateAddEquipmentNavigationService(s)));

            _services.AddSingleton(s => new OrdersListingViewModel(s.GetRequiredService<GenericStore<Order>>(),
                CreateAddPersonNavigationService(s),
                CreateAddOrdersNavigationService(s)));

            _services.AddSingleton(s => new ParametersListingViewModel(s.GetRequiredService<GenericStore<Parameter>>(),
                CreateAddPersonNavigationService(s),
                CreateAddParametersNavigationService(s)));

            _services.AddSingleton(s => new ProcessesTechnologiesListingViewModel(s.GetRequiredService<GenericStore<ProcessTechnology>>(),
                CreateAddPersonNavigationService(s),
                CreateAddProcessTechnologiesNavigationService(s)));

            _services.AddSingleton(s => new ProductCatalogListingViewModel(s.GetRequiredService<GenericStore<ProductCatalog>>(),
                CreateAddPersonNavigationService(s),
                CreateAddProductCatalogNavigationService(s)));

            _services.AddSingleton(s => new StagesListingViewModel(s.GetRequiredService<GenericStore<Stage>>(),
                CreateAddPersonNavigationService(s),
                CreateAddStagesNavigationService(s)));

            _services.AddSingleton(s => new WorksListingViewModel( s.GetRequiredService<IRepository<Work>>(),
                s.GetRequiredService<GenericStore<Work>>(),
                CreateAddPersonNavigationService(s),
                CreateAddWorksNavigationService(s)));

            #endregion

            #region AddingViewModels

            _services.AddTransient(s => new AddingBatchViewModel(s.GetRequiredService<GenericStore<Batch>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingBirdsTypesViewModel(s.GetRequiredService<GenericStore<BirdType>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingBirdsViewModel(s.GetRequiredService<GenericStore<Bird>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingCustomersViewModel(s.GetRequiredService<GenericStore<Customer>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingDepartmentsViewModel(s.GetRequiredService<GenericStore<Department>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingEmployeesInDepartmentsViewModel());

            _services.AddTransient(s => new AddingEmployeesViewModel(s.GetRequiredService<GenericStore<Employee>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingOrdersViewModel(s.GetRequiredService<GenericStore<Order>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingParametersViewModel(s.GetRequiredService<GenericStore<Parameter>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingProcessesViewModel(s.GetRequiredService<GenericStore<Process>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingProcessTechnologiesViewModel());

            _services.AddTransient(s => new AddingProductCatalogViewModel(s.GetRequiredService<GenericStore<ProductCatalog>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingStagesViewModel(s.GetRequiredService<GenericStore<Stage>>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingWorksViewModel(s.GetRequiredService<GenericStore<Work>>(),
                s.GetRequiredService<CloseModalNavigationService>()));


            //_services.AddTransient(s => new AddingPersonViewModel(s.GetRequiredService<PeopleStore>(),
            //                                                      CreatePeopleListingNavigationService(s)));

            _services.AddTransient(s => new AddingPersonViewModel(s.GetRequiredService<PeopleStore>(),
                                                                  s.GetRequiredService<CloseModalNavigationService>()));

            _services.AddTransient(s => new AddingPeopleViewModel(s.GetRequiredService<PeopleStore>(),
                                                                  s.GetRequiredService<CloseModalNavigationService>()));
            #endregion

            _services.AddTransient(CreateNavigationBarViewModel);
            _services.AddSingleton<MainViewModel>();
        }

        private void AddWindows()
        {
            //var s = string.Empty;
            _services.AddSingleton(s => new MainWindow
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
        }
        #region Service ViewModels

        
        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider) =>
            new(_aCSP.GetRequiredService<IAuthenticator>(),
                CreateHomeNavigationService(serviceProvider),
                CreateAccountNavigationService(serviceProvider),
                CreatePeopleListingNavigationService(serviceProvider),
                CreateHubViewModelNavigationService(serviceProvider)
               );

        private INavigationService CreateHubViewModelNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<HubViewModel>(
                                                      serviceProvider.GetRequiredService<NavigationStore>(),
                                                      () => serviceProvider.GetRequiredService<HubViewModel>(),
                                                      () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                     );
        private INavigationService CreatePeopleListingNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<PeopleListingViewModel>(
                                                                serviceProvider.GetRequiredService<NavigationStore>(),
                                                                () => serviceProvider.GetRequiredService<PeopleListingViewModel>(),
                                                                () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                                );



        private INavigationService CreateAddPeopleNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingPeopleViewModel>(
                                                               serviceProvider.GetRequiredService<ModalNavigationStore>(),
                                                               () => serviceProvider.GetRequiredService<AddingPeopleViewModel>()
                                                             );
        private INavigationService CreateAddPersonNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingPersonViewModel>(
                                                              serviceProvider.GetRequiredService<ModalNavigationStore>(),
                                                              () => serviceProvider.GetRequiredService<AddingPersonViewModel>()
                                                              );
        

        /// <summary>
        /// Добавляет сервис навигации.
        /// </summary>
        /// <remarks> В случае решения поменять тип сервиса: Modal заменить на обычный,
        /// а в ViewModel вместо выдачи компонента использовать этот метод. </remarks>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        //private INavigationService CreateAddPersonNavigationService(IServiceProvider serviceProvider) =>
        //    new NavigationService<AddingPersonViewModel>(
        //                                                 serviceProvider.GetRequiredService<NavigationStore>(),
        //                                                 () => serviceProvider.GetRequiredService<AddingPersonViewModel>()
        //                                                );

        private LayoutNavigationService<HomeViewModel> CreateHomeNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<HomeViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<HomeViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<AccountViewModel>(
                                                          serviceProvider.GetRequiredService<NavigationStore>(),
                                                          () => serviceProvider.GetRequiredService<AccountViewModel>(),
                                                          () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                          );

        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<LoginViewModel>(
                                                        serviceProvider.GetRequiredService<ModalNavigationStore>(),
                                                        () => serviceProvider.GetRequiredService<LoginViewModel>()
                                                      );

        private INavigationService CreateRegistrationNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<RegisterViewModel>(
                                                          serviceProvider.GetRequiredService<ModalNavigationStore>(),
                                                          () => serviceProvider.GetRequiredService<RegisterViewModel>()
                                                         );



        private LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService compositeNavigationService = new CompositeNavigationService(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateAccountNavigationService(serviceProvider)
                );

            return new LoginViewModel(
                                      _aCSP.GetRequiredService<IAuthenticator>(),
                                      compositeNavigationService,
                                      CreateRegistrationNavigationService(serviceProvider)
                                     );
        }
        #endregion

        #region Adding Navigation Services

        private INavigationService CreateAddBatchesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingBatchViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingBatchViewModel>()
            );

        private INavigationService CreateAddBirdsTypesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingBirdsTypesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingBirdsTypesViewModel>()
            );

        private INavigationService CreateAddBirdsNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingBirdsViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingBirdsViewModel>()
            );

        private INavigationService CreateAddCustomersNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingCustomersViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingCustomersViewModel>()
            );

        private INavigationService CreateAddDepartmentsNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingDepartmentsViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingDepartmentsViewModel>()
            );

        private INavigationService CreateAddEmployeesInDepartmentsNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingEmployeesInDepartmentsViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingEmployeesInDepartmentsViewModel>()
            );

        private INavigationService CreateAddEmployeesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingEmployeesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingEmployeesViewModel>()
            );

        private INavigationService CreateAddEquipmentNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingEquipmentViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingEquipmentViewModel>()
            );

        private INavigationService CreateAddOrdersNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingOrdersViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingOrdersViewModel>()
            );

        private INavigationService CreateAddParametersNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingParametersViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingParametersViewModel>()
            );

        private INavigationService CreateAddProcessesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingProcessesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingProcessesViewModel>()
            );

        private INavigationService CreateAddProcessTechnologiesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingProcessTechnologiesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingProcessTechnologiesViewModel>()
            );

        private INavigationService CreateAddProductCatalogNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingProductCatalogViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingProductCatalogViewModel>()
            );

        private INavigationService CreateAddStagesNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingStagesViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingStagesViewModel>()
            );

        private INavigationService CreateAddWorksNavigationService(IServiceProvider serviceProvider) =>
            new ModalNavigationService<AddingWorksViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddingWorksViewModel>()
            );

        #endregion

        #region Hub ViewModels

        private INavigationService CreateBatchesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<BatchesListingViewModel>(
                                                                 serviceProvider.GetRequiredService<NavigationStore>(),
                                                                 () => serviceProvider.GetRequiredService<BatchesListingViewModel>(),
                                                                 () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                                 );
        private INavigationService CreateBirdsListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<BirdsListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<BirdsListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateBirdsTypesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<BirdsTypesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<BirdsTypesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateCustomersListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<CustomersListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<CustomersListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateDepartmentsListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<DepartmentsListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<DepartmentsListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateEmployeesInDepartmentsListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<EmployeesInDepartmentsListingViewModel>(
                                                                                serviceProvider.GetRequiredService<NavigationStore>(),
                                                                                () => serviceProvider.GetRequiredService<EmployeesInDepartmentsListingViewModel>(),
                                                                                () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                                                );
        private INavigationService CreateEmployeesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<EmployeesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<EmployeesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateEquipmentListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<EquipmentListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<EquipmentListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateOrdersListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<OrdersListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<OrdersListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateParametersListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<ParametersListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ParametersListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
            );

        private INavigationService CreateProcessesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<ProcessesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<ProcessesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateProcessesTechnologyListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<ProcessesTechnologiesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<ProcessesTechnologiesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateProductCatalogListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<ProductCatalogListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<ProductCatalogListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );

        private INavigationService CreateStagesListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<StagesListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<StagesListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );
        private INavigationService CreateWorksListingViewModel(IServiceProvider serviceProvider) =>
            new LayoutNavigationService<WorksListingViewModel>(
                                                       serviceProvider.GetRequiredService<NavigationStore>(),
                                                       () => serviceProvider.GetRequiredService<WorksListingViewModel>(),
                                                       () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
                                                       );



        #endregion

    }
}
