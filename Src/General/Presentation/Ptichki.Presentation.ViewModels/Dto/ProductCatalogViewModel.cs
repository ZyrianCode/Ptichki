using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class ProductCatalogViewModel : ViewModelBase
    {
        public ProductCatalog ProductCatalog { get; set; }

        public ProductCatalogViewModel(ProductCatalog productCatalog)
        {
            ProductCatalog = productCatalog;
        }
    }
}
