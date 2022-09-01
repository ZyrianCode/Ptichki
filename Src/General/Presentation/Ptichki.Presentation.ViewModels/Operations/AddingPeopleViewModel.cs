using System.Windows.Input;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Data.Stores;
using Ptichki.Presentation.Commands.Adding;
using Ptichki.Presentation.ViewModels.Abstractions.Operations;

namespace Ptichki.Presentation.ViewModels.Operations
{
    public class AddingPeopleViewModel : ViewModelBase, IAddingPeopleViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddingPeopleViewModel(PeopleStore peopleStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddPeopleCommand(this, peopleStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
