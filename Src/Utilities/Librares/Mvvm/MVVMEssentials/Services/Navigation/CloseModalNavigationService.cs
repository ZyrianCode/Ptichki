using MVVMEssentials.Services.Abstract;
using MVVMEssentials.Stores.Navigation;

namespace MVVMEssentials.Services.Navigation
{
    public class CloseModalNavigationService : INavigationService
    {
        private readonly ModalNavigationStore _navigationStore;

        public CloseModalNavigationService(ModalNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void Navigate() => 
            _navigationStore.Close();
    }
}
