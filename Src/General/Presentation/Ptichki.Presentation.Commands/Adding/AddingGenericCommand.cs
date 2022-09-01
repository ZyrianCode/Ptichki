using System.Windows.Input;
using MVVMEssentials.Commands.Sync.Base;
using MVVMEssentials.Services.Abstract;
using Ptichki.Data.Stores;

namespace Ptichki.Presentation.Commands.Adding
{
    public class AddingGenericCommand<TModel> : CommandBase
    {
        private readonly ICommand _command;
        private readonly GenericStore<TModel> _genericStore;
        private readonly INavigationService _navigationService;

        public AddingGenericCommand(ICommand command,
                                    GenericStore<TModel> genericStore,
                                    INavigationService navigationService)
        {
            _command = command;
            _genericStore = genericStore;
            _navigationService = navigationService;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            _command.Execute(parameter);
            _genericStore.OperationComplete();

            _navigationService.Navigate();
        }
    }
}
