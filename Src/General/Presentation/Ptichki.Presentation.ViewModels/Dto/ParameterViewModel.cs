using MVVMEssentials.ViewModels;
using Ptichki.Domain.Models;

namespace Ptichki.Presentation.ViewModels.Dto
{
    public class ParameterViewModel : ViewModelBase
    {
        public Parameter Parameter { get; set; }

        public ParameterViewModel(Parameter parameter)
        {
            Parameter = parameter;
        }
    }
}
