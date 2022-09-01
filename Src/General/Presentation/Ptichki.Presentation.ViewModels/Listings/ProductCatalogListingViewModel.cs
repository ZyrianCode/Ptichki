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
    public class ProductCatalogListingViewModel : ViewModelBase
    {
        private readonly GenericStore<ProductCatalog> _productCatalogsStore;

        private readonly ObservableCollection<ProductCatalogViewModel> _productCatalogs;
        public IEnumerable<ProductCatalogViewModel> ProductCatalogs => _productCatalogs;

        public ICommand AddProductCatalogCommand { get; }
        public ICommand AddProductCatalogsCommand { get; }
        public ICommand UpdateProductCatalogsCommand { get; }

        public ProductCatalogListingViewModel(GenericStore<ProductCatalog> productCatalogStore,
                                              INavigationService addProductCatalogNavigationService,
                                              INavigationService addProductCatalogsNavigationService)
        {
            _productCatalogsStore = productCatalogStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddProductCatalogCommand = new NavigateCommand(addProductCatalogNavigationService);
            AddProductCatalogsCommand = new NavigateCommand(addProductCatalogsNavigationService);
            UpdateProductCatalogsCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _productCatalogs = new ObservableCollection<ProductCatalogViewModel>();

            _productCatalogsStore.SingleModelAdded += OnProductCatalogAdded;
            _productCatalogsStore.MultipleModelAdded += OnProductCatalogsAdded;
            _productCatalogsStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateProductCatalogsCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<ProductCatalog>().ToList();
            _productCatalogsStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnProductCatalogAdded(ProductCatalog productCatalog)
        {
            _productCatalogs.Add(new ProductCatalogViewModel(productCatalog));
        }

        private void OnProductCatalogsAdded(IEnumerable<ProductCatalog> productCatalogs)
        {
            foreach (var productCatalog in productCatalogs)
            {
                _productCatalogs.Add(new ProductCatalogViewModel(productCatalog));
            }
        }
    }
}
