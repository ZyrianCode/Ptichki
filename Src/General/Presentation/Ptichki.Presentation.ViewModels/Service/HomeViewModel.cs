using System.Windows.Input;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;

namespace Ptichki.Presentation.ViewModels.Service
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Памагииитееее...";

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(INavigationService loginNavigationService)
        {
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }
    }
}
