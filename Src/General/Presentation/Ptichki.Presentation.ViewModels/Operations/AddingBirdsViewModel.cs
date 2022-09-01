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
    public class AddingBirdsViewModel : ViewModelBase
    {
        private string _birdName;
        public string BirdName
        {
            get => _birdName;
            set
            {
                _birdName = value;
                OnPropertyChanged(nameof(BirdName));
            }
        }

        private string _birdSex;
        public string BirdSex
        {
            get => _birdSex;
            set
            {
                _birdSex = value;
                OnPropertyChanged(nameof(BirdSex));
            }
        }

        private string _birdAge;
        public string BirdAge
        {
            get => _birdAge;
            set
            {
                _birdAge = value;
                OnPropertyChanged(nameof(BirdAge));
            }
        }

        private string _birdWeight;
        public string BirdWeight
        {
            get => _birdWeight;
            set
            {
                _birdWeight = value;
                OnPropertyChanged(nameof(BirdWeight));
            }
        }

        private string _feedConsumption;
        public string FeedConsumption
        {
            get => _feedConsumption;
            set
            {
                _feedConsumption = value;
                OnPropertyChanged(nameof(FeedConsumption));
            }
        }

        private string _waterConsumption;
        public string WaterConsumption
        {
            get => _waterConsumption;
            set
            {
                _waterConsumption = value;
                OnPropertyChanged(nameof(WaterConsumption));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand InsertCommand { get; }

        public AddingBirdsViewModel(GenericStore<Bird> birdStore, INavigationService closeNavigationService)
        {
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            InsertCommand = new InsertCommand(this, requestStore, new DefaultModeInserterBehavior());
            SubmitCommand = new AddingGenericCommand<Bird>(InsertCommand, birdStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
