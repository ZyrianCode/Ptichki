using System;
using System.Threading.Tasks;
using Authentication.Core.Abstractions.Authenticators;
using Authentication.Core.Abstractions.Data.Stores;
using Authentication.Core.Abstractions.Services;
using Authentication.Core.Models;
using Authentication.Helpers;

namespace Authentication.Tools.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }

        public Account CurrentAccount
        {
            get => _accountStore.CurrentAccount;
            private set
            {
                _accountStore.CurrentAccount = value;
                CurrentAccountChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action CurrentAccountChanged;

        public async Task Login(string username, string password)
        {
            CurrentAccount = await _authenticationService.Login(username, password);
        }
        
        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword) => 
            await _authenticationService.Register(email, username, password, confirmPassword);
    }
}
