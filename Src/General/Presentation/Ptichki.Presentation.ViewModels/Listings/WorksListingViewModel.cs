using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MICS.Helpers.Core.Abstractions;
using MVVMEssentials.Commands.Async.Base;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Application.Micqrs.Db;
using Ptichki.Data.Micqrs.Behaviors.Readers;
using Ptichki.Data.Micqrs.Stores.Db;
using Ptichki.Data.Stores;
using Ptichki.Domain.Abstractions.Repositories;
using Ptichki.Domain.Models;
using Ptichki.Presentation.ViewModels.Dto;

namespace Ptichki.Presentation.ViewModels.Listings
{
    public class WorksListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Work> _worksStore;
        
        private readonly ObservableCollection<WorkViewModel> _works;
        public IEnumerable<WorkViewModel> Works => _works;
        private readonly IRepository<Work> _repository;

        public ICommand AddWorkCommand { get; }
        public ICommand AddWorksCommand { get; }
        public ICommand UpdateWorksCommand { get; }
        public ICommand LoadDbData { get; }
        public WorksListingViewModel(IRepository<Work> workRepository,
                                     GenericStore<Work> workStore,
                                     INavigationService addWorkNavigationService,
                                     INavigationService addWorksNavigationService)
        {
            _worksStore = workStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            _repository = workRepository;
            LoadDbData = new AsyncRelayCommand(Load, OnException);


            AddWorkCommand = new NavigateCommand(addWorkNavigationService);
            AddWorksCommand = new NavigateCommand(addWorksNavigationService);
            UpdateWorksCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _works = new ObservableCollection<WorkViewModel>();
            
            _worksStore.SingleModelAdded += OnWorkAdded;
            _worksStore.MultipleModelAdded += OnWorksAdded;
            _worksStore.OperationCompleted += OnOperationCompleted;
        }

        private Task Load()
        {
            var works = _repository.Items.ToList();
            foreach (var work in works)
            {
                _works.Add(new WorkViewModel(work));
            }
            return Task.CompletedTask;
        }

        private void OnException(Exception exception)
        { }

        private void OnOperationCompleted()
        {
            UpdateWorksCommand.Execute(null);   
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Work>().ToList();
            _worksStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnWorkAdded(Work work)
        {
            _works.Add(new WorkViewModel(work));
        }

        private void OnWorksAdded(IEnumerable<Work> works)
        {
            foreach (var work in works)
            {
                _works.Add(new WorkViewModel(work));
            }
        }
    }
}
