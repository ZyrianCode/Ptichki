using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Parameter : NamedObject
    {
        public string Description { get; set; }
        public ICollection<ProcessTechnology> ProcessTechnologies { get; set; }
    }
}
