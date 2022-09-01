using System.Windows.Input;
using MICS.Helpers.Core.Abstractions;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Application.Micqrs.Db;
using Ptichki.Data.Micqrs.Behaviors.Inserters;
using Ptichki.Data.Micqrs.Stores.Db;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;
using Ptichki.Presentation.Commands.Adding;

namespace Ptichki.Presentation.ViewModels.Operations
{
    public class AddingOrdersViewModel : ViewModelBase
    {
        private string _orderDate;
        public string OrderDate
        {
            get => _orderDate;
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }

        private string _orderPrice;
        public string OrderPrice
        {
            get => _orderPrice;
            set
            {
                _orderPrice = value;
                OnPropertyChanged(nameof(OrderPrice));
            }
        }

        private string _transactionCode;

        public string TransactionCode
        {
            get => _transactionCode;
            set
            {
                _transactionCode = value;
                OnPropertyChanged(nameof(TransactionCode));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand InsertCommand { get; }

        public AddingOrdersViewModel(GenericStore<Order> ordersStore, INavigationService closeNavigationService)
        {
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            InsertCommand = new InsertCommand(this, requestStore, new DefaultModeInserterBehavior());
            SubmitCommand = new AddingGenericCommand<Order>(InsertCommand, ordersStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }

    }
}
