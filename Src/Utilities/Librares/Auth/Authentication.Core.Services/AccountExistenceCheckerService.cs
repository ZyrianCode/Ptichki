using System.Threading.Tasks;
using Authentication.Core.Abstractions.Data.Services;
using Authentication.Core.Abstractions.Services;
using Authentication.Core.Exceptions;
using Authentication.Core.Models;
using Authentication.Helpers;

namespace Authentication.Core.Services
{
    public class AccountExistenceCheckerService : IAccountExistenceCheckerService
    {
        private readonly IAccountService _accountService;
        private Account _account;

        public AccountExistenceCheckerService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<RegistrationResult> CheckExistenceForRegistration(string email)
        {
            _account = await _accountService.GetByEmail(email);
            return _account != null ? RegistrationResult.AccountAlreadyExists : RegistrationResult.Success;
        }

        public async Task<Account> CheckExistenceForLogin(string email)
        {
            _account = await _accountService.GetByEmail(email);
            if (_account == null)
            {
                throw new UserNotFoundException(email);
            }

            return _account;
        }
    }
}
