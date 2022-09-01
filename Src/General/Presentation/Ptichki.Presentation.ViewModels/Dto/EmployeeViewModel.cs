using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class EmployeeViewModel : ViewModelBase
    {
        public Employee Employee { get; set; }

        public EmployeeViewModel(Employee employee)
        {
            Employee = employee;
        }
    }
}
