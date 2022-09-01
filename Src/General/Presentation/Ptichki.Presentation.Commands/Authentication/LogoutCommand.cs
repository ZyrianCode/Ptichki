using Authentication.Core.Abstractions.Authenticators;
using MVVMEssentials.Commands.Sync.Base;

namespace Ptichki.Presentation.Commands.Authentication
{
    public class LogoutCommand : CommandBase
    {
        private readonly IAuthenticator _authenticator;

        public LogoutCommand(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            _authenticator.Logout();
        }
    }
}
