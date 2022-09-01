using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Authentication.Core.Abstractions.Authenticators;
using Authentication.Core.Exceptions;
using MVVMEssentials.Commands.Async.Base;
using MVVMEssentials.Services.Abstract;
using Ptichki.Presentation.ViewModels.Abstractions.Authorization;

namespace Ptichki.Presentation.Commands.Authentication
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoggingViewModelBase _viewModel;
        private readonly IAuthenticator _authenticator;
        private readonly INavigationService _compositeNavigationService;

        public LoginCommand(LoggingViewModelBase viewModel,
                            IAuthenticator authenticator,
                            INavigationService compositeNavigationService
                           )
        {
            _viewModel = viewModel;
            _authenticator = authenticator;
            _compositeNavigationService = compositeNavigationService;
            _viewModel.PropertyChanged += ViewModelChanged;
        }

        private void ViewModelChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoggingViewModelBase.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter) =>
           _viewModel.CanLogin && base.CanExecute(parameter);


        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.ErrorMessage = string.Empty;

            try
            {
                await _authenticator.Login(_viewModel.Email, _viewModel.Password);

                _compositeNavigationService.Navigate();
            }
            catch (UserNotFoundException)
            {
                _viewModel.ErrorMessage = "User does not exist.";
            }
            catch (InvalidPasswordException)
            {
                _viewModel.ErrorMessage = "Incorrect password.";
            }
            catch (Exception)
            {
                _viewModel.ErrorMessage = "Login failed.";
                _compositeNavigationService.Navigate(); //Как закончишь тест, убери.
            }
        }
    }
}
