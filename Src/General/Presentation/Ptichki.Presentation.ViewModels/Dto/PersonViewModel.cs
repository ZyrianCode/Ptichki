using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class PersonViewModel : ViewModelBase
    {
        public string Name { get; }
        public Person Person { get; }

        public PersonViewModel(string name)
        {
            Name = name;
        }

        public PersonViewModel(Person person)
        {
            Person = person;
        }
    }
}
