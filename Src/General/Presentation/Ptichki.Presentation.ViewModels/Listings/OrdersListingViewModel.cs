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
    public class OrdersListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Order> _ordersStore;

        private readonly ObservableCollection<OrderViewModel> _orders;
        public IEnumerable<OrderViewModel> Orders => _orders;

        public ICommand AddOrderCommand { get; }
        public ICommand AddOrdersCommand { get; }
        public ICommand UpdateOrdersCommand { get; }

        public OrdersListingViewModel(GenericStore<Order> orderStore,
                                      INavigationService addOrderNavigationService,
                                      INavigationService addOrdersNavigationService)
        {
            _ordersStore = orderStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddOrderCommand = new NavigateCommand(addOrderNavigationService);
            AddOrdersCommand = new NavigateCommand(addOrdersNavigationService);
            UpdateOrdersCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _orders = new ObservableCollection<OrderViewModel>();

            _ordersStore.SingleModelAdded += OnOrderAdded;
            _ordersStore.MultipleModelAdded += OnOrdersAdded;
            _ordersStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateOrdersCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Order>().ToList();
            _ordersStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnOrderAdded(Order order)
        {
            _orders.Add(new OrderViewModel(order));
        }

        private void OnOrdersAdded(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                _orders.Add(new OrderViewModel(order));
            }
        }
    }
}
