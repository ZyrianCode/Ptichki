
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Models
{
    public class Person : NamedObject
    {
        public Person(string name)
        {
            Name = name;
        }
    }
}
