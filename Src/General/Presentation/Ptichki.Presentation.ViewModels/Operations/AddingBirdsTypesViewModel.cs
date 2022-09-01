using System.Windows.Input;
using MICS.Helpers.Core.Abstractions;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Application.Micqrs.Db;
using Ptichki.Data.Micqrs.Behaviors.Inserters;
using Ptichki.Data.Micqrs.Stores.Db;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;
using Ptichki.Presentation.Commands.Adding;

namespace Ptichki.Presentation.ViewModels.Operations
{
    public class AddingBirdsTypesViewModel : ViewModelBase
    {
        private string _birdTypeName;
        public string BirdTypeName
        {
            get => _birdTypeName;
            set
            {
                _birdTypeName = value;
                OnPropertyChanged(nameof(BirdTypeName));
            }
        }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand InsertCommand { get; }

        public AddingBirdsTypesViewModel(GenericStore<BirdType> birdTypeStore, INavigationService closeNavigationService)
        {
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            InsertCommand = new InsertCommand(this, requestStore, new DefaultModeInserterBehavior());
            SubmitCommand = new AddingGenericCommand<BirdType>(InsertCommand, birdTypeStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
