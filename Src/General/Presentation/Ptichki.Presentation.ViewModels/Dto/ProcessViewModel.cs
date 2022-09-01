using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class ProcessViewModel : ViewModelBase
    {
        public Process Process { get; set; }

        public ProcessViewModel(Process process)
        {
            Process = process;
        }
    }
}
