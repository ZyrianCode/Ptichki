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
    public class BatchesListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Batch> _batchStore;

        private readonly ObservableCollection<BatchViewModel> _batches;
        public IEnumerable<BatchViewModel> Batches => _batches;

        public ICommand AddBatchCommand { get; }
        public ICommand AddBatchesCommand { get; }
        public ICommand UpdateBatchesCommand { get; }

        public BatchesListingViewModel(GenericStore<Batch> batchStore,
                                       INavigationService addBatchNavigationService,
                                       INavigationService addBatchesNavigationService)
        {
            _batchStore = batchStore;

            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddBatchCommand = new NavigateCommand(addBatchNavigationService);
            AddBatchesCommand = new NavigateCommand(addBatchesNavigationService);
            UpdateBatchesCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _batches = new ObservableCollection<BatchViewModel>();

            _batchStore.SingleModelAdded += OnBatchAdded;
            _batchStore.MultipleModelAdded += OnBatchesAdded;
            _batchStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateBatchesCommand.Execute(null);
        }

        private void OnBatchAdded(Batch batch)
        {
            _batches.Add(new BatchViewModel(batch));
        }

        private void OnBatchesAdded(IEnumerable<Batch> batches)
        {
            foreach (var batch in batches)
            {
                _batches.Add(new BatchViewModel(batch));
            }
        }

        
        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Batch>().ToList();
            _batchStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }
    }
}