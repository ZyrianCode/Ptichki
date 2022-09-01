using System.Collections.Generic;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Bird : NamedObject
    {
        public string BirdSex { get; set; }
        public int BirdAge { get; set; }
        public float BirdWeight { get; set; }
        public float FeedConsumption { get; set; }
        public float WaterConsumption { get; set; }
        public ICollection<Work> Works { get; set; }
        public BirdType BirdTypes { get; set; }
    }
}
