using System.Threading.Tasks;
using Authentication.Core.Models;
using Authentication.Helpers;

namespace Authentication.Core.Abstractions.Services
{
    public interface IAccountExistenceCheckerService
    {
        public Task<RegistrationResult> CheckExistenceForRegistration(string email);
        public Task<Account> CheckExistenceForLogin(string email);
    }
}
