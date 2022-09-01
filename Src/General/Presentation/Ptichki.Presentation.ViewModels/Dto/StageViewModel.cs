using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class StageViewModel : ViewModelBase
    {
        public Stage Stage { get; set; }

        public StageViewModel(Stage stage)
        {
            Stage = stage;
        }
    }
}
