using System;
using MVVMEssentials.Layouts;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.Stores.Navigation;
using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Services.Navigation
{
    public class GenericLayoutNavigationService<TViewModel, TNavigationBar> : INavigationService 
        where TViewModel : ViewModelBase, new()
        where TNavigationBar : class, IDisposable, new()

    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<TNavigationBar> _createNavigationBarViewModel;

        public GenericLayoutNavigationService(NavigationStore navigationStore,
                                              Func<TViewModel> createViewModel,
                                              Func<TNavigationBar> createNavigationBarViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel =
                new GenericLayoutViewModel<TNavigationBar>(_createNavigationBarViewModel(), _createViewModel());
        }
    }
}
