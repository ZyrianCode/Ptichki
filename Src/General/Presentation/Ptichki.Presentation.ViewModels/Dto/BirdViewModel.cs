using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class BirdViewModel : ViewModelBase
    {
        public Bird Bird { get; set; }

        public BirdViewModel(Bird bird)
        {
            Bird = bird;
        }
    }
}
