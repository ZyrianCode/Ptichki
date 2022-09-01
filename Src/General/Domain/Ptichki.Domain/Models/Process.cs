using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Process : NamedObject
    {
        public Stage Stage { get; set; }
        public ICollection<Work> Works { get; set; }
        public ICollection<ProcessTechnology> ProcessTechnologies { get; set; }
    }
}
