using System;
using MVVMEssentials.ViewModels;

namespace Ptichki.Presentation.ViewModels.Layouts
{
    public class GenericLayoutViewModel<TNavigationBarViewModel> : ViewModelBase
    where TNavigationBarViewModel : IDisposable
    {
        public TNavigationBarViewModel NavigationBarViewModel { get; }
        public ViewModelBase ContentViewModel { get; }

        public GenericLayoutViewModel(TNavigationBarViewModel navigationBarViewModel, ViewModelBase contentViewModel)
        {
            NavigationBarViewModel = navigationBarViewModel;
            ContentViewModel = contentViewModel;
        }
        public override void Dispose()
        {
            NavigationBarViewModel.Dispose();
            ContentViewModel.Dispose();

            base.Dispose();
        }
    }
}
