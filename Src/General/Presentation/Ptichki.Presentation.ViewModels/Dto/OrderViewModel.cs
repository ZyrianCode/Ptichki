using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class OrderViewModel : ViewModelBase
    {
        public Order Order { get; set; }

        public OrderViewModel(Order order)
        {
            Order = order;
        }
    }
}
