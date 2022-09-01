using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MICS.Helpers.Core.Abstractions;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Application.Micqrs.Db;
using Ptichki.Data.Micqrs.Behaviors.Readers;
using Ptichki.Data.Micqrs.Stores.Db;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;
using Ptichki.Presentation.ViewModels.Dto;

namespace Ptichki.Presentation.ViewModels.Listings
{
    public class BirdsTypesListingViewModel : ViewModelBase
    {
        private readonly GenericStore<BirdType> _birdTypesStore;

        private readonly ObservableCollection<BirdTypeViewModel> _birdTypes;
        public IEnumerable<BirdTypeViewModel> BirdTypes => _birdTypes;

        public ICommand AddBirdTypeCommand { get; }
        public ICommand AddBirdTypesCommand { get; }
        public ICommand UpdateBirdTypesCommand { get; }

        public BirdsTypesListingViewModel(GenericStore<BirdType> birdTypeStore,
                                          INavigationService addBirdTypeNavigationService,
                                          INavigationService addBirdTypesNavigationService)
        {
            _birdTypesStore = birdTypeStore;

            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddBirdTypeCommand = new NavigateCommand(addBirdTypeNavigationService);
            AddBirdTypesCommand = new NavigateCommand(addBirdTypesNavigationService);
            UpdateBirdTypesCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _birdTypes = new ObservableCollection<BirdTypeViewModel>();

            _birdTypesStore.SingleModelAdded += OnBirdTypeAdded;
            _birdTypesStore.MultipleModelAdded += OnBirdTypesAdded;
            _birdTypesStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateBirdTypesCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<BirdType>().ToList();
            _birdTypesStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnBirdTypeAdded(BirdType birdType)
        {
            _birdTypes.Add(new BirdTypeViewModel(birdType));
        }

        private void OnBirdTypesAdded(IEnumerable<BirdType> birdTypes)
        {
            foreach (var birdType in birdTypes)
            {
                _birdTypes.Add(new BirdTypeViewModel(birdType));
            }
        }
    }
}
