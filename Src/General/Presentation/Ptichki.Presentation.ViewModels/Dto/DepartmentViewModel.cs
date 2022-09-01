using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class DepartmentViewModel : ViewModelBase
    {
        public Department Department { get; set; }

        public DepartmentViewModel(Department department)
        {
            Department = department;
        }
    }
}
