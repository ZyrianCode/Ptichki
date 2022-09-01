using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class WorkViewModel : ViewModelBase
    {
        public Work Work { get; set; }

        public WorkViewModel(Work work)
        {
            Work = work;
        }
    }
}
