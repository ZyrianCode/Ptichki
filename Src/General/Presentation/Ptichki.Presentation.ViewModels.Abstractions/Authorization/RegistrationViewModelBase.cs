using MVVMEssentials.ViewModels;

namespace Ptichki.Presentation.ViewModels.Abstractions.Authorization
{
    public abstract class RegistrationViewModelBase : ViewModelBase    
    {
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public bool CanRegister => !string.IsNullOrEmpty(Email) &&
                                   !string.IsNullOrEmpty(Username) &&
                                   !string.IsNullOrEmpty(Password) &&
                                   !string.IsNullOrEmpty(ConfirmPassword) &&
                                   ConfirmPassword == Password;

        public MessageViewModel ErrorMessageViewModel { get; set; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
    }
}
