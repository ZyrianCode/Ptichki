
using MVVMEssentials.ViewModels;

namespace Ptichki.Presentation.ViewModels.Abstractions.Authorization
{
    public abstract class LoggingViewModelBase : ViewModelBase
    {
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
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
                OnPropertyChanged(nameof(CanLogin));
            }
        }
        public bool CanLogin => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);

        public MessageViewModel ErrorMessageViewModel { get; set; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
    }
}
