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
    public class AddingParametersViewModel : ViewModelBase
    {
        private string _parameterName;
        public string ParameterName
        {
            get => _parameterName;
            set
            {
                _parameterName = value;
                OnPropertyChanged(nameof(ParameterName));
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand InsertCommand { get; }

        public AddingParametersViewModel(GenericStore<Parameter> parameterStore, INavigationService closeNavigationService)
        {
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            InsertCommand = new InsertCommand(this, requestStore, new DefaultModeInserterBehavior());
            SubmitCommand = new AddingGenericCommand<Parameter>(InsertCommand, parameterStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
