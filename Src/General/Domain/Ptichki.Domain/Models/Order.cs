using System;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Order : DomainObject
    {
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderPrice { get; set; }
        public string TransactionCode { get; set; }
    }
}
