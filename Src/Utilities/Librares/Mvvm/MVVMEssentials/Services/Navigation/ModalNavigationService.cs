﻿using System;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.Stores.Navigation;
using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Services.Navigation
{
    public class ModalNavigationService<TViewModel> : INavigationService 
        where TViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public ModalNavigationService(ModalNavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
