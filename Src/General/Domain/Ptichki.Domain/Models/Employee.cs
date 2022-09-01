using System;
using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Employee : IdentityObject
    {
        public DateTime DateOfBirthday { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportSerial { get; set; }
        public string PassportNumber { get; set; }
        public ICollection<Work> Works { get; set; }
        public ICollection<EmployeesInDepartments> EmployeesInDepartments { get; set; }
    }
}
