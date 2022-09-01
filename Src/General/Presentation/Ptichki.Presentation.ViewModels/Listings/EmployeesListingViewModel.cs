using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MICS.Helpers.Core.Abstractions;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Application.Micqrs.Db;
using Ptichki.Data.Micqrs.Behaviors.Readers;
using Ptichki.Data.Micqrs.Stores.Db;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;
using Ptichki.Presentation.ViewModels.Dto;

namespace Ptichki.Presentation.ViewModels.Listings
{
    public class EmployeesListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Employee> _employeesStore;

        private readonly ObservableCollection<EmployeeViewModel> _employees;
        public IEnumerable<EmployeeViewModel> Employees => _employees;

        public ICommand AddEmployeeCommand { get; }
        public ICommand AddEmployeesCommand { get; }
        public ICommand UpdateEmployeesCommand { get; }

        public EmployeesListingViewModel(GenericStore<Employee> employeeStore,
                                         INavigationService addEmployeeNavigationService,
                                         INavigationService addEmployeesNavigationService)
        {
            _employeesStore = employeeStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddEmployeeCommand = new NavigateCommand(addEmployeeNavigationService);
            AddEmployeesCommand = new NavigateCommand(addEmployeesNavigationService);
            UpdateEmployeesCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _employees = new ObservableCollection<EmployeeViewModel>();

            _employeesStore.SingleModelAdded += OnEmployeeAdded;
            _employeesStore.MultipleModelAdded += OnEmployeesAdded;
            _employeesStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateEmployeesCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Employee>().ToList();
            _employeesStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnEmployeeAdded(Employee employee)
        {
            _employees.Add(new EmployeeViewModel(employee));
        }

        private void OnEmployeesAdded(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                _employees.Add(new EmployeeViewModel(employee));
            }
        }
    }
}
