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
    public class StagesListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Stage> _stagesStore;

        private readonly ObservableCollection<StageViewModel> _stages;
        public IEnumerable<StageViewModel> Stages => _stages;

        public ICommand AddStageCommand { get; }
        public ICommand AddStagesCommand { get; }
        public ICommand UpdateStagesCommand { get; }

        public StagesListingViewModel(GenericStore<Stage> stageStore,
                                      INavigationService addStageNavigationService,
                                      INavigationService addStagesNavigationService)
        {
            _stagesStore = stageStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddStageCommand = new NavigateCommand(addStageNavigationService);
            AddStagesCommand = new NavigateCommand(addStagesNavigationService);
            UpdateStagesCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _stages = new ObservableCollection<StageViewModel>();

            _stagesStore.SingleModelAdded += OnStageAdded;
            _stagesStore.MultipleModelAdded += OnStagesAdded;
            _stagesStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateStagesCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Stage>().ToList();
            _stagesStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnStageAdded(Stage stage)
        {
            _stages.Add(new StageViewModel(stage));
        }

        private void OnStagesAdded(IEnumerable<Stage> stages)
        {
            foreach (var stage in stages)
            {
                _stages.Add(new StageViewModel(stage));
            }
        }
    }
}
