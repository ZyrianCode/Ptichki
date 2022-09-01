using System.Windows.Input;
using Authentication.Core.Abstractions.Authenticators;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Presentation.Commands.Authentication;
using Ptichki.Presentation.ViewModels.Abstractions.Authorization;

namespace Ptichki.Presentation.ViewModels.Authorization
{
    public class RegisterViewModel : RegistrationViewModelBase
    {
        public ICommand RegisterCommand { get; }
        public ICommand NavigateToLoginPageCommand { get; }

        public RegisterViewModel(IAuthenticator authenticator,
                                 INavigationService registrationNavigationService,
                                 INavigationService loginNavigationService
                                )
        {
            ErrorMessageViewModel = new MessageViewModel();

            RegisterCommand = new RegisterCommand(this, authenticator, registrationNavigationService); 
            NavigateToLoginPageCommand = new NavigateCommand(loginNavigationService);
        }
        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();
            base.Dispose();
        }
    }
}
