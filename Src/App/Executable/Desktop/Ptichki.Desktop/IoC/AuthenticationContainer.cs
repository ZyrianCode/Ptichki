using System;
using Authentication.Core.Abstractions.Authenticators;
using Authentication.Core.Abstractions.Data.Services;
using Authentication.Core.Abstractions.Data.Stores;
using Authentication.Core.Abstractions.Services;
using Authentication.Core.Models;
using Authentication.Core.Services;
using Authentication.Tools.Authenticators;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ptichki.Data.Authentication.Services;
using Ptichki.Data.Authentication.Stores;

namespace Ptichki.Desktop.IoC
{
    public class AuthenticationContainer
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _serviceProvider;

        public IServiceProvider ServiceProvider => _serviceProvider;

        public AuthenticationContainer()
        {
            _services = new ServiceCollection();
        }

        public void Start()
        {
            AddAuthenticationServices();

            _serviceProvider = _services.BuildServiceProvider();
        }

        private void AddAuthenticationServices()
        {
            _services.AddSingleton<IPasswordHasher<Account>, PasswordHasher<Account>>();

            _services.AddSingleton<IVerificationService, VerificationService>();

            _services.AddSingleton<IDataService<Account>, AccountDataService>();
            _services.AddSingleton<IAccountService, AccountDataService>();
            _services.AddSingleton<IAccountExistenceCheckerService, AccountExistenceCheckerService>();
            _services.AddSingleton<IAccountCreationService, AccountCreationService>();

            _services.AddSingleton<IAuthenticationService, AuthenticationService>();
            _services.AddSingleton<IAccountStore, AccountStore>();
            _services.AddSingleton<IAuthenticator, Authenticator>();

            _services.AddSingleton(CreateAuthenticator);
        }

        private IAuthenticator CreateAuthenticator(IServiceProvider serviceProvider) =>
            new Authenticator(
                CreateAuthenticationService(serviceProvider),
                serviceProvider.GetRequiredService<IAccountStore>()
            );

        private IAuthenticationService CreateAuthenticationService(IServiceProvider serviceProvider) =>
            new AuthenticationService(
                CreateVerificationService(serviceProvider),
                CreateAccountExistenceCheckerService(serviceProvider),
                CreateAccountCreationService(serviceProvider)
            );

        private IVerificationService CreateVerificationService(IServiceProvider serviceProvider) =>
            new VerificationService(serviceProvider.GetRequiredService<IPasswordHasher<Account>>());


        private IAccountExistenceCheckerService CreateAccountExistenceCheckerService(IServiceProvider serviceProvider) =>
            new AccountExistenceCheckerService(serviceProvider.GetRequiredService<IAccountService>());

        private IAccountCreationService CreateAccountCreationService(IServiceProvider serviceProvider) =>
            new AccountCreationService(
                serviceProvider.GetRequiredService<IPasswordHasher<Account>>(),
                serviceProvider.GetRequiredService<IAccountService>()
            );
    }
}
