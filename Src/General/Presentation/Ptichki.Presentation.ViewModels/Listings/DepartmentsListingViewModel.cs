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
    public class DepartmentsListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Department> _departmentStore;

        private readonly ObservableCollection<DepartmentViewModel> _departments;
        public IEnumerable<DepartmentViewModel> Departments => _departments;

        public ICommand AddDepartmentCommand { get; }
        public ICommand AddDepartmentsCommand { get; }
        public ICommand UpdateDepartmentsCommand { get; }

        public DepartmentsListingViewModel(GenericStore<Department> departmentStore,
                                           INavigationService addDepartmentNavigationService,
                                           INavigationService addDepartmentsNavigationService)
        {
            _departmentStore = departmentStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddDepartmentCommand = new NavigateCommand(addDepartmentNavigationService);
            AddDepartmentsCommand = new NavigateCommand(addDepartmentsNavigationService);

            _departments = new ObservableCollection<DepartmentViewModel>();
            UpdateDepartmentsCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _departmentStore.SingleModelAdded += OnDepartmentAdded;
            _departmentStore.MultipleModelAdded += OnDepartmentsAdded;
            _departmentStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateDepartmentsCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Department>().ToList();
            _departmentStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnDepartmentAdded(Department department)
        {
            _departments.Add(new DepartmentViewModel(department));
        }

        private void OnDepartmentsAdded(IEnumerable<Department> departments)
        {
            foreach (var department in departments)
            {
                _departments.Add(new DepartmentViewModel(department));
            }
        }
    }
}
