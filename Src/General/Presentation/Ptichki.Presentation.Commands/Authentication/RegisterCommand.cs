using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Authentication.Core.Abstractions.Authenticators;
using Authentication.Helpers;
using MVVMEssentials.Commands.Async.Base;
using MVVMEssentials.Services.Abstract;
using Ptichki.Presentation.ViewModels.Abstractions.Authorization;

namespace Ptichki.Presentation.Commands.Authentication
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegistrationViewModelBase _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly INavigationService _navigationService;

        public RegisterCommand(RegistrationViewModelBase registrationViewModel,
                               IAuthenticator authenticator,
                               INavigationService navigationService
                               )
        {
            _registerViewModel = registrationViewModel;
            _authenticator = authenticator;
            _navigationService = navigationService;

            _registerViewModel.PropertyChanged += ViewModelChanged;
        }

        private void ViewModelChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(RegistrationViewModelBase.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter) => 
            _registerViewModel.CanRegister && base.CanExecute(parameter);

        public override async Task ExecuteAsync(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                RegistrationResult registrationResult = await _authenticator.Register(_registerViewModel.Email,
                                                                                      _registerViewModel.Username,
                                                                                      _registerViewModel.Password,
                                                                                      _registerViewModel.ConfirmPassword
                                                                                      );
                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _navigationService.Navigate();
                        break;

                    case RegistrationResult.PasswordsDoNotMatch:
                        _registerViewModel.ErrorMessage =
                            $"{nameof(RegistrationResult.PasswordsDoNotMatch)} confirm password";
                        break;

                    case RegistrationResult.AccountAlreadyExists:
                        _registerViewModel.ErrorMessage = $"{nameof(RegistrationResult.AccountAlreadyExists)}";
                        break;

                    default:
                        _registerViewModel.ErrorMessage = "Registration failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = "Registration failed.";
                throw;
            }
        }
    }
}
