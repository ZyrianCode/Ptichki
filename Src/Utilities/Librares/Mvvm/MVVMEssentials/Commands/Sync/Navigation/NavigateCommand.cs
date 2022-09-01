using MVVMEssentials.Commands.Sync.Base;
using MVVMEssentials.Services.Abstract;

namespace MVVMEssentials.Commands.Sync.Navigation
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
