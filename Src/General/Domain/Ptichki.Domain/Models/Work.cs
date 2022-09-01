using System;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Work : NamedObject
    {
        public Batch Batch { get; set; }
        public Employee Employee { get; set; }
        public Process Process { get; set; }
        public Equipment Equipment { get; set; }
        public Bird Bird { get; set; }
        public DateTime DueDate { get; set; }
    }
}
