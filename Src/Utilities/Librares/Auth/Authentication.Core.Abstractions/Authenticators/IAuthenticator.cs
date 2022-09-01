using System;
using System.Threading.Tasks;
using Authentication.Core.Models;
using Authentication.Helpers;

namespace Authentication.Core.Abstractions.Authenticators
{
    public interface IAuthenticator
    {
        public Account CurrentAccount { get; }
        public bool IsLoggedIn { get; }

        event Action CurrentAccountChanged;

        public Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        public Task Login(string username, string password);

        void Logout();
    }
}
