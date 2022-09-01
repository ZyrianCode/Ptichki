using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;
using Ptichki.Presentation.ViewModels.Dto;

namespace Ptichki.Presentation.ViewModels.Listings
{
    public class PeopleListingViewModel : ViewModelBase
    {
        private readonly PeopleStore _peopleStore;

        private readonly ObservableCollection<PersonViewModel> _people;

        public IEnumerable<PersonViewModel> People => _people;

        public ICommand AddPersonCommand { get; }
        public ICommand AddPeopleCommand { get; }

        public PeopleListingViewModel(PeopleStore peopleStore, 
                                      INavigationService addPersonNavigationService,
                                      INavigationService addPeopleNavigationService
                                     )
        {
            _peopleStore = peopleStore;

            AddPersonCommand = new NavigateCommand(addPersonNavigationService);
            AddPeopleCommand = new NavigateCommand(addPeopleNavigationService);

            _people = new ObservableCollection<PersonViewModel>();

            _people.Add(new PersonViewModel(new Person("Андрей")));
            _people.Add(new PersonViewModel(new Person("Катя")));
            _people.Add(new PersonViewModel(new Person("Егор")));

            _peopleStore.PersonAdded += OnPersonAdded;
            _peopleStore.PeopleAdded += OnPeopleAdded;
        }

        private void OnPeopleAdded(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                _people.Add(new PersonViewModel(person));
            }
        }

        private void OnPersonAdded(Person person)
        {
            _people.Add(new PersonViewModel(person));
        }
    }
}
