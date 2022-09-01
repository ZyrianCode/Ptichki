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
    public class AddingProductCatalogViewModel : ViewModelBase
    {
        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private string _weight;
        public string Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private string _cost;
        public string Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }

        private string _composition;

        public string Composition
        {
            get => _composition;
            set
            {
                _composition = value;
                OnPropertyChanged(nameof(Composition));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand InsertCommand { get; }

        public AddingProductCatalogViewModel(GenericStore<ProductCatalog> productCatalogsStore, INavigationService closeNavigationService)
        {
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            InsertCommand = new InsertCommand(this, requestStore, new DefaultModeInserterBehavior());
            SubmitCommand = new AddingGenericCommand<ProductCatalog>(InsertCommand, productCatalogsStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
