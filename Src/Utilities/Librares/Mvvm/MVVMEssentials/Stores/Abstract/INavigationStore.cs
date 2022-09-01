using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Stores.Abstract
{
    public interface INavigationStore
    {
        ViewModelBase CurrentViewModel { set; }
    }
}