
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class EmployeesInDepartments : DomainObject
    {
        public Employee Employee { get; set; }
        public Department Department { get; set; }
    }
}
