using MVVMEssentials.Services.Abstract;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class HubNavigationDto
    {
        public INavigationService Batches { get; set; }
        public INavigationService Birds { get; set; }
        public INavigationService BirdsTypes { get; set; }
        public INavigationService Customers { get; set; }
        public INavigationService Departments { get; set; }
        public INavigationService EmployeesInDepartments { get; set; }
        public INavigationService Employees { get; set; }
        public INavigationService Equipment { get; set; }
        public INavigationService Orders { get; set; }
        public INavigationService Parameters { get; set; }
        public INavigationService Processes { get; set; }
        public INavigationService ProcessesTechnologies { get; set; }
        public INavigationService ProductCatalog { get; set; }
        public INavigationService Stages { get; set; }
        public INavigationService Works { get; set; }

        public HubNavigationDto(
                                INavigationService batchesNavigationService,
                                INavigationService birdsNavigationService,
                                INavigationService birdsTypesNavigationService,
                                INavigationService customersNavigationService,
                                INavigationService departmentsNavigationService,
                                INavigationService employeesInDepartmentsNavigationService,
                                INavigationService employeesNavigationService,
                                INavigationService equipmentNavigationService,
                                INavigationService ordersNavigationService,
                                INavigationService parametersNavigationService,
                                INavigationService processesNavigationService,
                                INavigationService processesTechnologiesNavigationService,
                                INavigationService productCatalogNavigationService,
                                INavigationService stagesNavigationService,
                                INavigationService worksNavigationService
                              )
        {
            Batches = batchesNavigationService;
            Birds = birdsNavigationService;
            BirdsTypes = birdsTypesNavigationService;
            Customers = customersNavigationService;
            Departments = departmentsNavigationService;
            EmployeesInDepartments = employeesInDepartmentsNavigationService;
            Employees = employeesNavigationService;
            Equipment = equipmentNavigationService;
            Orders = ordersNavigationService;
            Parameters = parametersNavigationService;
            Processes = processesNavigationService;
            ProcessesTechnologies = processesTechnologiesNavigationService;
            ProductCatalog = productCatalogNavigationService;
            Stages = stagesNavigationService;
            Works = worksNavigationService;
        }
    }
}
