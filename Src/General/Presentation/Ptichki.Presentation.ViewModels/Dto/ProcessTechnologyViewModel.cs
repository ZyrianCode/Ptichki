using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class ProcessTechnologyViewModel : ViewModelBase
    {
        public ProcessTechnology ProcessTechnology { get; set; }

        public ProcessTechnologyViewModel(ProcessTechnology processTechnology)
        {
            ProcessTechnology = processTechnology;
        }
    }
}
