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
    public class CustomersListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Customer> _customerStore;

        private readonly ObservableCollection<CustomerViewModel> _customers;
        public IEnumerable<CustomerViewModel> Customers => _customers;

        public ICommand AddCustomerCommand { get; }
        public ICommand AddCustomersCommand { get; }
        public ICommand UpdateCustomersCommand { get; }

        public CustomersListingViewModel(GenericStore<Customer> customerStore,
                                         INavigationService addCustomerNavigationService,
                                         INavigationService addCustomersNavigationService)
        {
            _customerStore = customerStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddCustomerCommand = new NavigateCommand(addCustomerNavigationService);
            AddCustomersCommand = new NavigateCommand(addCustomersNavigationService);
            UpdateCustomersCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _customers = new ObservableCollection<CustomerViewModel>();

            _customerStore.SingleModelAdded += OnCustomerAdded;
            _customerStore.MultipleModelAdded += OnCustomersAdded;
            _customerStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateCustomersCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Customer>().ToList();
            _customerStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnCustomerAdded(Customer customer)
        {
            _customers.Add(new CustomerViewModel(customer));
        }

        private void OnCustomersAdded(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                _customers.Add(new CustomerViewModel(customer));
            }
        }
    }
}
