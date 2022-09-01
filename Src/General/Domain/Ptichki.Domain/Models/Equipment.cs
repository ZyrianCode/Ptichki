using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Equipment : NamedObject
    {
        public ICollection<Work> Works { get; set; }
        public ICollection<ProcessTechnology> ProcessTechnologies { get; set; }
    }
}
