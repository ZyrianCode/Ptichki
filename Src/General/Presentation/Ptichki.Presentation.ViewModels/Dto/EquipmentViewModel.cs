using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class EquipmentViewModel : ViewModelBase
    {
        public Equipment EquipmentUnit { get; set; }

        public EquipmentViewModel(Equipment equipmentUnit)
        {
            EquipmentUnit = equipmentUnit;
        }
    }
}
