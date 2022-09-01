using System;
using System.Threading.Tasks;

namespace MVVMEssentials.Commands.Async.Base
{
    public class AsyncRelayCommand : AsyncCommandBase
    {
        private readonly Func<Task> _callback;
        public AsyncRelayCommand(Func<Task> callback, Action<Exception> onException)
        {
            _callback = callback;
        }

        public override async Task ExecuteAsync(object parameter) => 
            await _callback();
    }
}
