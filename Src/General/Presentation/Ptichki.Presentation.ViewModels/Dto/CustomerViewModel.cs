using System.Collections.ObjectModel;
using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class CustomerViewModel : ViewModelBase
    {
        public Customer Customer { get; set; }
        public CustomerViewModel(Customer customer)
        {
            Customer = customer;
        }
    }
}
