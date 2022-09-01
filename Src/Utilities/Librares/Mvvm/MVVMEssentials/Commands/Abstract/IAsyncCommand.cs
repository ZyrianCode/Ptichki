using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMEssentials.Commands.Abstract
{
    public interface IAsyncCommand : ICommand
    {
        public Task ExecuteAsync(object parameter);
    }
}
