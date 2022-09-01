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
    public class BirdsListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Bird> _birdsStore;

        private readonly ObservableCollection<BirdViewModel> _birds;
        public IEnumerable<BirdViewModel> Birds => _birds;

        public ICommand AddBirdCommand { get; }
        public ICommand AddBirdsCommand { get; }
        public ICommand UpdateBirdsCommand { get; }

        public BirdsListingViewModel(GenericStore<Bird> birdsStore,
                                     INavigationService addBirdNavigationService,
                                     INavigationService addBirdsNavigationService)
        {
            _birdsStore = birdsStore;

            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddBirdCommand = new NavigateCommand(addBirdNavigationService);
            AddBirdsCommand = new NavigateCommand(addBirdsNavigationService);
            UpdateBirdsCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _birds = new ObservableCollection<BirdViewModel>();

            _birdsStore.SingleModelAdded += OnBirdAdded;
            _birdsStore.MultipleModelAdded += OnBirdsAdded;
            _birdsStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateBirdsCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Bird>().ToList();
            _birdsStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnBirdAdded(Bird bird)
        {
            _birds.Add(new BirdViewModel(bird));
        }

        private void OnBirdsAdded(IEnumerable<Bird> birds)
        {
            foreach (var bird in birds)
            {
                _birds.Add(new BirdViewModel(bird));
            }
        }
    }
}
