using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Stage : NamedObject
    {
        public ICollection<Process> Processes { get; set; }
    }
}
