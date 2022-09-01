using System;
using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Batch : DomainObject
    {
        public string CountOfProduct { get; set; }
        public DateTime CreationDate { get; set; }
        public ProductCatalog Catalog { get; set; }
        public ICollection<OrderComposition> OrderCompositions { get; set; }
        public ICollection<Work> Works { get; set; }
    }
}
