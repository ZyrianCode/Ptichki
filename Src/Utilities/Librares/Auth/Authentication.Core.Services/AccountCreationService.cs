using System;
using System.Threading.Tasks;
using Authentication.Core.Abstractions.Data.Services;
using Authentication.Core.Abstractions.Services;
using Authentication.Core.Models;
using Authentication.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Services
{
    public class AccountCreationService : IAccountCreationService
    {
        private readonly IPasswordHasher<Account> _passwordHasher;
        private readonly IAccountService _accountService;

        public AccountCreationService(IPasswordHasher<Account> passwordHasher, IAccountService accountService)
        {
            _passwordHasher = passwordHasher;
            _accountService = accountService;
        }

        public async Task<Account> CreateAccount(string email, string username, string password)
        {
            string hashedPassword = _passwordHasher.HashPassword(new Account(), password);

            User user = new User()
            {
                Email = email,
                Username = username,
                PasswordHash = hashedPassword,
                DateJoined = DateTime.Now
            };

            Account newAccount = new Account()
            {
                AccountHolder = user,
                Balance = 0,
                Session = SessionStatus.Active
            };

           return await _accountService.Create(newAccount);
        }
    }
}
