using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Department : NamedObject
    {
        public string DepartmentType { get; set; }
        public ICollection<EmployeesInDepartments> EmployeesInDepartments { get; set; }
    }
}
