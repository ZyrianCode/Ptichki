using MVVMEssentials.Commands.Sync.Base;
using MVVMEssentials.Services.Abstract;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;
using Ptichki.Presentation.ViewModels.Abstractions.Operations;

namespace Ptichki.Presentation.Commands.Adding
{
    public class AddPersonCommand : CommandBase
    {
        private readonly IAddingPersonViewModel _addingPersonViewModel;
        private readonly PeopleStore _peopleStore;
        private readonly INavigationService _navigationService;

        public AddPersonCommand(IAddingPersonViewModel addingPersonViewModel,
                                PeopleStore peopleStore, 
                                INavigationService navigationService)
        {
            _addingPersonViewModel = addingPersonViewModel;
            _peopleStore = peopleStore;
            _navigationService = navigationService;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Person person = new Person(_addingPersonViewModel.Name);
            _peopleStore.AddPerson(person);

            _navigationService.Navigate();
        }
    }
}
