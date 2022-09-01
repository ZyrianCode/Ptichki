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
using Ptichki.Desktop.Factories;

namespace Ptichki.Desktop.Registrators
{
    public static class AuthenticationServicesRegistrator
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services) => services
            .AddSingleton<IPasswordHasher<Account>, PasswordHasher<Account>>()

            .AddSingleton<IVerificationService, VerificationService>()

            .AddSingleton<IDataService<Account>, AccountDataService>()
            .AddSingleton<IAccountService, AccountDataService>()
            .AddSingleton<IAccountExistenceCheckerService, AccountExistenceCheckerService>()
            .AddSingleton<IAccountCreationService, AccountCreationService>()

            .AddSingleton<IAuthenticationService, AuthenticationService>()
            .AddSingleton<IAccountStore, AccountStore>()
            .AddSingleton<IAuthenticator, Authenticator>()

            .AddSingleton(AuthenticationServicesFactories.CreateAuthenticator);
    }
}
