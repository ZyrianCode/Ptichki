using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class ProductCatalog : NamedObject
    {
        public float Weight { get; set; }
        public float Price { get; set; }
        public string Composition { get; set; }
        public ICollection<Batch> Batches { get; set; }
        public ICollection<ProcessTechnology> ProcessTechnologies { get; set; }
    }
}
