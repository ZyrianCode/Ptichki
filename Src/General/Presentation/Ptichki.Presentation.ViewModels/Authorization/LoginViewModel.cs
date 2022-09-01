using System.Windows.Input;
using Authentication.Core.Abstractions.Authenticators;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Presentation.Commands.Authentication;
using Ptichki.Presentation.ViewModels.Abstractions.Authorization;

namespace Ptichki.Presentation.ViewModels.Authorization
{
    public class LoginViewModel : LoggingViewModelBase
    {
        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegisterPageCommand { get; }

        public LoginViewModel(IAuthenticator authenticator,
                              INavigationService compositeNavigationService,
                              INavigationService registrationNavigationService
                             )
        {
            ErrorMessageViewModel = new MessageViewModel();
            LoginCommand = new LoginCommand(this, authenticator, compositeNavigationService);
            NavigateToRegisterPageCommand = new NavigateCommand(registrationNavigationService);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();
            base.Dispose();
        }
    }
}
