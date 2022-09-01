using System.Threading.Tasks;
using Authentication.Core.Models;
using Authentication.Helpers;

namespace Authentication.Core.Abstractions.Services
{
    public interface IAuthenticationService
    {
        public Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        
        public Task<Account> Login(string email, string password);
    }
}
