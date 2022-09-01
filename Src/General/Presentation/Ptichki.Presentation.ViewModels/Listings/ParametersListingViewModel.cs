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
    public class ParametersListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Parameter> _parametersStore;

        private readonly ObservableCollection<ParameterViewModel> _parameters;
        public IEnumerable<ParameterViewModel> Parameters => _parameters;

        public ICommand AddParameterCommand { get; }
        public ICommand AddParametersCommand { get; }
        public ICommand UpdateParametersCommand { get; }

        public ParametersListingViewModel(GenericStore<Parameter> parametersStore,
                                          INavigationService addParameterNavigationService,
                                          INavigationService addParametersNavigationService)
        {
            _parametersStore = parametersStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddParameterCommand = new NavigateCommand(addParameterNavigationService);
            AddParametersCommand = new NavigateCommand(addParametersNavigationService);
            UpdateParametersCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _parameters = new ObservableCollection<ParameterViewModel>();

            _parametersStore.SingleModelAdded += OnParameterAdded;
            _parametersStore.MultipleModelAdded += OnParametersAdded;
            _parametersStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateParametersCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Parameter>().ToList();
            _parametersStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnParameterAdded(Parameter parameter)
        {
            _parameters.Add(new ParameterViewModel(parameter));
        }

        private void OnParametersAdded(IEnumerable<Parameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                _parameters.Add(new ParameterViewModel(parameter));
            }
        }
    }
}
