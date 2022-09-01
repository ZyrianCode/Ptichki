using MVVMEssentials.Commands.Sync.Base;
using MVVMEssentials.Services.Abstract;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;
using Ptichki.Presentation.ViewModels.Abstractions.Operations;

namespace Ptichki.Presentation.Commands.Adding
{
    public class AddPeopleCommand : CommandBase
    {
        private readonly IAddingPeopleViewModel _addingPeopleViewModel;
        private readonly PeopleStore _peopleStore;
        private readonly INavigationService _navigationService;

        public AddPeopleCommand(IAddingPeopleViewModel addingPeopleViewModel,
                                PeopleStore peopleStore,
                                INavigationService navigationService)
        {
            _addingPeopleViewModel = addingPeopleViewModel;
            _peopleStore = peopleStore;
            _navigationService = navigationService;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Person person = new Person(_addingPeopleViewModel.Name);
            _peopleStore.AddPerson(person);

            _navigationService.Navigate();
        }
    }
}
