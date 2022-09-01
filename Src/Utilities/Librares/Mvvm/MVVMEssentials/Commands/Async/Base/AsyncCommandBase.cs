using System;
using System.Threading.Tasks;
using MVVMEssentials.Commands.Abstract;

namespace MVVMEssentials.Commands.Async.Base
{
    public abstract class AsyncCommandBase : IAsyncCommand
    {
        private bool _isExecuting;
        private bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? CanExecuteChanged;

        protected void OnCanExecuteChanged() => 
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public virtual bool CanExecute(object parameter) => 
            !IsExecuting;

        public async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        /// <summary>
        /// Метод асинхронного выполнения
        /// </summary>
        /// <param name="parameter"></param>
        public abstract Task ExecuteAsync(object parameter);
    }
}
