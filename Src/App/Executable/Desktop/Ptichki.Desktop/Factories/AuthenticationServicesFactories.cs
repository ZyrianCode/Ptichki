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

namespace Ptichki.Desktop.Factories
{
    public static class AuthenticationServicesFactories
    {
        internal static IAuthenticator CreateAuthenticator(IServiceProvider serviceProvider) =>
            new Authenticator(
                CreateAuthenticationService(serviceProvider),
                serviceProvider.GetRequiredService<IAccountStore>()
            );

        private static IAuthenticationService CreateAuthenticationService(IServiceProvider serviceProvider) =>
            new AuthenticationService(
                CreateVerificationService(serviceProvider),
                CreateAccountExistenceCheckerService(serviceProvider),
                CreateAccountCreationService(serviceProvider)
            );

        private static IVerificationService CreateVerificationService(IServiceProvider serviceProvider) =>
            new VerificationService(serviceProvider.GetRequiredService<IPasswordHasher<Account>>());


        private static IAccountExistenceCheckerService CreateAccountExistenceCheckerService(IServiceProvider serviceProvider) =>
            new AccountExistenceCheckerService(serviceProvider.GetRequiredService<IAccountService>());

        private static IAccountCreationService CreateAccountCreationService(IServiceProvider serviceProvider) =>
            new AccountCreationService(
                serviceProvider.GetRequiredService<IPasswordHasher<Account>>(),
                serviceProvider.GetRequiredService<IAccountService>()
            );
    }
}
