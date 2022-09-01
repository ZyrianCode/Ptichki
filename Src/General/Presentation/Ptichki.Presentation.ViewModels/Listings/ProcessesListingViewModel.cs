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
    public class ProcessesListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Process> _processesStore;

        private readonly ObservableCollection<ProcessViewModel> _processes;
        public IEnumerable<ProcessViewModel> Processes => _processes;

        public ICommand AddProcessCommand { get; }
        public ICommand AddProcessesCommand { get; }
        public ICommand UpdateProcessesCommand { get; }

        public ProcessesListingViewModel(GenericStore<Process> processStore,
                                         INavigationService addProcessNavigationService,
                                         INavigationService addProcessesNavigationService)
        {
            _processesStore = processStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddProcessCommand = new NavigateCommand(addProcessNavigationService);
            AddProcessesCommand = new NavigateCommand(addProcessesNavigationService);
            UpdateProcessesCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _processes = new ObservableCollection<ProcessViewModel>();

            _processesStore.SingleModelAdded += OnProcessAdded;
            _processesStore.MultipleModelAdded += OnProcessesAdded;
            _processesStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateProcessesCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Process>().ToList();
            _processesStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }
        private void OnProcessAdded(Process process)
        {
            _processes.Add(new ProcessViewModel(process));
        }

        private void OnProcessesAdded(IEnumerable<Process> processes)
        {
            foreach (var process in processes)
            {
                _processes.Add(new ProcessViewModel(process));
            }
        }
    }
}
