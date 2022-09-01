using System.Windows.Input;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.ViewModels;
using Ptichki.Presentation.ViewModels.Dto;

namespace Ptichki.Presentation.ViewModels.Hubs
{
    public class HubViewModel : ViewModelBase
    {
        public ICommand OpenBatches { get; }
        public ICommand OpenBirds { get; } 
        public ICommand OpenBirdsTypes { get; } 
        public ICommand OpenCustomers { get; } 
        public ICommand OpenDepartments { get; } 
        public ICommand OpenEmployeesInDepartments { get; }
        public ICommand OpenEmployees { get; } 
        public ICommand OpenEquipment { get; } 
        public ICommand OpenOrders { get; }
        public ICommand OpenParameters { get; }
        public ICommand OpenProcesses { get; }
        public ICommand OpenProcessTechnologies { get; }
        public ICommand OpenProductCatalog { get; }
        public ICommand OpenStages { get; }
        public ICommand OpenWorks { get; }
        

        public HubViewModel(HubNavigationDto hubNavigationDto)
        {
            OpenBatches = new NavigateCommand(hubNavigationDto.Batches);
            OpenBirds = new NavigateCommand(hubNavigationDto.Birds);
            OpenBirdsTypes = new NavigateCommand(hubNavigationDto.BirdsTypes);
            OpenCustomers = new NavigateCommand(hubNavigationDto.Customers);
            OpenDepartments = new NavigateCommand(hubNavigationDto.Departments);
            OpenEmployeesInDepartments = new NavigateCommand(hubNavigationDto.EmployeesInDepartments);
            OpenEmployees = new NavigateCommand(hubNavigationDto.Employees);
            OpenEquipment = new NavigateCommand(hubNavigationDto.Equipment);
            OpenOrders = new NavigateCommand(hubNavigationDto.Orders);
            OpenParameters = new NavigateCommand(hubNavigationDto.Parameters);
            OpenProcesses = new NavigateCommand(hubNavigationDto.Processes);
            OpenProcessTechnologies = new NavigateCommand(hubNavigationDto.ProcessesTechnologies);
            OpenProductCatalog = new NavigateCommand(hubNavigationDto.ProductCatalog);
            OpenStages = new NavigateCommand(hubNavigationDto.Stages);
            OpenWorks = new NavigateCommand(hubNavigationDto.Works);
        }
    }
}
