using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class BirdType : NamedObject
    {
        public ICollection<Bird> Birds { get; set; }
    }
}
