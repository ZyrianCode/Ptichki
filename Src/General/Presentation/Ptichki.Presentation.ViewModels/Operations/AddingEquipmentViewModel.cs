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
    public class AddingEquipmentViewModel : ViewModelBase
    {
        private string _equipmentName;
        public string EquipmentName
        {
            get => _equipmentName;
            set
            {
                _equipmentName = value;
                OnPropertyChanged(nameof(EquipmentName));
            }
        }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand InsertCommand { get; }

        public AddingEquipmentViewModel(GenericStore<Equipment> equipmentStore, INavigationService closeNavigationService)
        {
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            InsertCommand = new InsertCommand(this, requestStore, new DefaultModeInserterBehavior());
            SubmitCommand = new AddingGenericCommand<Equipment>(InsertCommand, equipmentStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
