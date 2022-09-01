
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class ProcessTechnology : NamedObject
    {
        public ProductCatalog ProductCatalog { get; set; }
        public Process Process { get; set; }
        public Equipment Equipment { get; set; }
        public Parameter Parameter { get; set; }
        public string Value { get; set; }
    }
}
