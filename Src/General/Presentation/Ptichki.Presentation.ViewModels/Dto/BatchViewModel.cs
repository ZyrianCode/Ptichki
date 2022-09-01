using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class BatchViewModel : ViewModelBase
    {
        public Batch Batch { get; set; }

        public BatchViewModel(Batch batch)
        {
            Batch = batch;
        }
    }
}
