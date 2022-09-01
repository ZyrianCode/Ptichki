using System.Windows.Input;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Data.Stores;
using Ptichki.Presentation.Commands.Adding;
using Ptichki.Presentation.ViewModels.Abstractions.Operations;

namespace Ptichki.Presentation.ViewModels.Operations
{
    public class AddingPersonViewModel : ViewModelBase, IAddingPersonViewModel
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

        public AddingPersonViewModel(PeopleStore peopleStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddPersonCommand(this, peopleStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
