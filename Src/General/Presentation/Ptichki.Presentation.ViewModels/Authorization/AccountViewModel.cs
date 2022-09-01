using System.Windows.Input;
using Authentication.Core.Abstractions.Authenticators;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;

namespace Ptichki.Presentation.ViewModels.Authorization
{
    public class AccountViewModel : ViewModelBase 
    {
        private readonly IAuthenticator _authenticator;

        public string Username => _authenticator.CurrentAccount?.AccountHolder.Username;
        public string Email => _authenticator.CurrentAccount?.AccountHolder.Email;
        

        public ICommand NavigateHomeCommand { get; }

        public AccountViewModel(IAuthenticator authenticator, INavigationService homeNavigationService)
        {
            _authenticator = authenticator;

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);

            _authenticator.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Username));
        }

        public override void Dispose()
        {
            _authenticator.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
