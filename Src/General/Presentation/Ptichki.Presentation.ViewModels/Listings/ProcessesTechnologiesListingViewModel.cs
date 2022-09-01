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
    public class ProcessesTechnologiesListingViewModel : ViewModelBase
    {
        private readonly GenericStore<ProcessTechnology> _processTechnologiesStore;

        private readonly ObservableCollection<ProcessTechnologyViewModel> _processTechnologies;
        public IEnumerable<ProcessTechnologyViewModel> ProcessTechnologies => _processTechnologies;

        public ICommand AddProcessTechnologyCommand { get; }
        public ICommand AddProcessTechnologiesCommand { get; }
        public ICommand UpdateProcessTechnologiesCommand { get; }

        public ProcessesTechnologiesListingViewModel(GenericStore<ProcessTechnology> processTechnologyStore,
                                                     INavigationService addProcessTechnologyNavigationService,
                                                     INavigationService addProcessTechnologiesNavigationService)
        {
            _processTechnologiesStore = processTechnologyStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddProcessTechnologyCommand = new NavigateCommand(addProcessTechnologyNavigationService);
            AddProcessTechnologiesCommand = new NavigateCommand(addProcessTechnologiesNavigationService);
            UpdateProcessTechnologiesCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _processTechnologies = new ObservableCollection<ProcessTechnologyViewModel>();

            _processTechnologiesStore.SingleModelAdded += OnProcessTechnologyAdded;
            _processTechnologiesStore.MultipleModelAdded += OnProcessTechnologiesAdded;
            _processTechnologiesStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateProcessTechnologiesCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<ProcessTechnology>().ToList();
            _processTechnologiesStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnProcessTechnologyAdded(ProcessTechnology processTechnology)
        {
            _processTechnologies.Add(new ProcessTechnologyViewModel(processTechnology));
        }

        private void OnProcessTechnologiesAdded(IEnumerable<ProcessTechnology> processTechnologies)
        {
            foreach (var processTechnology in processTechnologies)
            {
                _processTechnologies.Add(new ProcessTechnologyViewModel(processTechnology));
            }
        }
    }
}
