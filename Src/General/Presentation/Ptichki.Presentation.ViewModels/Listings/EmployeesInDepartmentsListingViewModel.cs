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
    public class EmployeesInDepartmentsListingViewModel : ViewModelBase
    {
        private readonly GenericStore<EmployeesInDepartments> _employeesInDepartmentsStore;

        private readonly ObservableCollection<EmployeesInDepartmentsViewModel> _employeesInDepartments;
        public IEnumerable<EmployeesInDepartmentsViewModel> EmployeeInDepartments => _employeesInDepartments;

        public ICommand AddEmployeeInDepartmentsCommand { get; }
        public ICommand AddEmployeesInDepartmentsCommand { get; }
        public ICommand UpdateEmployeesInDepartmentsCommand { get; }

        public EmployeesInDepartmentsListingViewModel(GenericStore<EmployeesInDepartments> employeeStore,
                                                      INavigationService addEmployeeInDepartmentsNavigationService,
                                                      INavigationService addEmployeesInDepartmentsNavigationService)
        {
            _employeesInDepartmentsStore = employeeStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddEmployeeInDepartmentsCommand = new NavigateCommand(addEmployeeInDepartmentsNavigationService);
            AddEmployeesInDepartmentsCommand = new NavigateCommand(addEmployeesInDepartmentsNavigationService);
            UpdateEmployeesInDepartmentsCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _employeesInDepartments = new ObservableCollection<EmployeesInDepartmentsViewModel>();

            _employeesInDepartmentsStore.SingleModelAdded += OnEmployeeInDepartmentsAdded;
            _employeesInDepartmentsStore.MultipleModelAdded += OnEmployeeInDepartmentsAdded;
            _employeesInDepartmentsStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateEmployeesInDepartmentsCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<EmployeesInDepartments>().ToList();
            _employeesInDepartmentsStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnEmployeeInDepartmentsAdded(EmployeesInDepartments employee)
        {
            _employeesInDepartments.Add(new EmployeesInDepartmentsViewModel(employee));
        }

        private void OnEmployeeInDepartmentsAdded(IEnumerable<EmployeesInDepartments> employeesInDepartments)
        {
            foreach (var employee in employeesInDepartments)
            {
                _employeesInDepartments.Add(new EmployeesInDepartmentsViewModel(employee));
            }
        }
    }
}
