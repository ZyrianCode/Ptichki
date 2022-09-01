using System;
using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Customer : IdentityObject
    {
        public DateTime DateOfBirthday { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
