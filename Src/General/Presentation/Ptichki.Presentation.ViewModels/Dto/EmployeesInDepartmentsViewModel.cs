using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class EmployeesInDepartmentsViewModel : ViewModelBase
    {
        public EmployeesInDepartments EmployeeInDepartments { get; set; }

        public EmployeesInDepartmentsViewModel(EmployeesInDepartments employeeInDepartments)
        {
            EmployeeInDepartments = employeeInDepartments;
        }
    }
}
