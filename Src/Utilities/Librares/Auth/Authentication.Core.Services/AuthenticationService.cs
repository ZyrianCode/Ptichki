using System.Threading.Tasks;
using Authentication.Core.Abstractions.Services;
using Authentication.Core.Models;
using Authentication.Helpers;

namespace Authentication.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IVerificationService _verificationService;
        private readonly IAccountExistenceCheckerService _accountExistenceCheckerService;
        private readonly IAccountCreationService _accountCreationService;

        public AuthenticationService(IVerificationService verificationService,
                                     IAccountExistenceCheckerService accountExistenceCheckerService,
                                     IAccountCreationService accountCreationService
                                     )
        {
            _verificationService = verificationService;
            _accountExistenceCheckerService = accountExistenceCheckerService;
            _accountCreationService = accountCreationService;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                return RegistrationResult.PasswordsDoNotMatch;
            }

            RegistrationResult result = await _accountExistenceCheckerService.CheckExistenceForRegistration(email);

            if (result == RegistrationResult.Success)
            {
                await _accountCreationService.CreateAccount(email, username, password);
            }

            return result;
        }

        public async Task<Account> Login(string email, string password)
        {

            Account storedAccount = await _accountExistenceCheckerService.CheckExistenceForLogin(email);

            var hashedPassword = storedAccount.AccountHolder.PasswordHash;
            _verificationService.VerifyPassword(email, hashedPassword, password);

            return storedAccount;
        }
    }
}
