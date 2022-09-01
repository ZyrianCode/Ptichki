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
    public class EquipmentListingViewModel : ViewModelBase
    {
        private readonly GenericStore<Equipment> _equipmentsStore;

        private readonly ObservableCollection<EquipmentViewModel> _equipments;
        public IEnumerable<EquipmentViewModel> Equipments => _equipments;

        public ICommand AddEquipmentCommand { get; }
        public ICommand AddEquipmentsCommand { get; }
        public ICommand UpdateEquipmentsCommand { get; }

        public EquipmentListingViewModel(GenericStore<Equipment> equipmentStore,
                                         INavigationService addEquipmentNavigationService,
                                         INavigationService addEquipmentsNavigationService)
        {
            _equipmentsStore = equipmentStore;
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";

            AddEquipmentCommand = new NavigateCommand(addEquipmentNavigationService);
            AddEquipmentsCommand = new NavigateCommand(addEquipmentsNavigationService);
            UpdateEquipmentsCommand = new SelectCommand(this, requestStore, new DefaultModeReaderBehavior());

            _equipments = new ObservableCollection<EquipmentViewModel>();

            _equipmentsStore.SingleModelAdded += OnEquipmentAdded;
            _equipmentsStore.MultipleModelAdded += OnEquipmentsAdded;
            _equipmentsStore.OperationCompleted += OnOperationCompleted;
        }

        private void OnOperationCompleted()
        {
            UpdateEquipmentsCommand.Execute(null);
        }

        public override void UpdateCollections(IEnumerable<object> collection)
        {
            var list = collection.Cast<Equipment>().ToList();
            _equipmentsStore.AddMultipleModel(list);
            base.UpdateCollections(collection);
        }

        private void OnEquipmentAdded(Equipment equipment)
        {
            _equipments.Add(new EquipmentViewModel(equipment));
        }

        private void OnEquipmentsAdded(IEnumerable<Equipment> equipments)
        {
            foreach (var equipment in equipments)
            {
                _equipments.Add(new EquipmentViewModel(equipment));
            }
        }
    }
}
