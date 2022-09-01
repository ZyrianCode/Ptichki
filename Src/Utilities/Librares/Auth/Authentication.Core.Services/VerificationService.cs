using Authentication.Core.Abstractions.Services;
using Authentication.Core.Exceptions;
using Authentication.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Services
{
    public class VerificationService : IVerificationService
    {
        private readonly IPasswordHasher<Account> _passwordHasher;

        public VerificationService(IPasswordHasher<Account> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public void VerifyPassword(string email, string hashedPassword, string password)
        {
            PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(new Account(), hashedPassword, password);
            CheckVerificationResult(verificationResult, email, password);
        }

        private static void CheckVerificationResult(PasswordVerificationResult verificationResult, string email, string password)
        {
            if (verificationResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(email, password);
            }
        }
    }
}
