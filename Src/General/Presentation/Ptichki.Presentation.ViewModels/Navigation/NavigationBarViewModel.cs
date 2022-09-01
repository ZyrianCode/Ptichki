using System.Windows.Input;
using Authentication.Core.Abstractions.Authenticators;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Presentation.Commands.Authentication;

namespace Ptichki.Presentation.ViewModels.Navigation
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        public bool IsLoggedIn => _authenticator.IsLoggedIn;

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigatePeopleListingCommand { get; }
        public ICommand NavigateHubViewModel { get; }

        public ICommand LogoutCommand { get; }

        public NavigationBarViewModel(IAuthenticator authenticator,
                                      INavigationService homeNavigationService,
                                      INavigationService accountNavigationService,
                                      INavigationService peopleListingNavigationService,
                                      INavigationService hubViewModelNavigationService
                                     )
        {
            _authenticator = authenticator;

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigatePeopleListingCommand = new NavigateCommand(peopleListingNavigationService);
            NavigateHubViewModel = new NavigateCommand(hubViewModelNavigationService);

            LogoutCommand = new LogoutCommand(_authenticator);

            _authenticator.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        public override void Dispose()
        {
            _authenticator.CurrentAccountChanged -= OnCurrentAccountChanged;
            base.Dispose();
        }
    }
}
