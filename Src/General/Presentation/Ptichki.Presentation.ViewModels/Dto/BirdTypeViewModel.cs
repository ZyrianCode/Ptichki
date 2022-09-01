using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class BirdTypeViewModel : ViewModelBase
    {
        public BirdType BirdType { get; set; }

        public BirdTypeViewModel(BirdType birdType)
        {
            BirdType = birdType;
        }
    }
}
