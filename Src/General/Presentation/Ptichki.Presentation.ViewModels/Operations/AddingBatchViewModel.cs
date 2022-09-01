using System;
using System.Windows.Input;
using MICS.Helpers.Core.Abstractions;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Application.Micqrs.Db;
using Ptichki.Data.Micqrs.Behaviors.Inserters;
using Ptichki.Data.Micqrs.Stores.Db;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;
using Ptichki.Presentation.Commands.Adding;

namespace Ptichki.Presentation.ViewModels.Operations
{
    public class AddingBatchViewModel : ViewModelBase
    {
        private string _productCount;
        public string ProductCount
        { 
            get => _productCount;
            set
            {
                _productCount = value;
                OnPropertyChanged(nameof(ProductCount));   
            }
        }

        private DateTime _dateOfCreation;
        public DateTime DateOfCreation
        { 
            get => _dateOfCreation;
            set
            {
                _dateOfCreation = value;
                OnPropertyChanged(nameof(DateOfCreation));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand InsertCommand { get; }

        public AddingBatchViewModel(GenericStore<Batch> batchStore, INavigationService closeNavigationService)
        {
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";
            
            InsertCommand = new InsertCommand(this, requestStore, new DefaultModeInserterBehavior());
            SubmitCommand = new AddingGenericCommand<Batch>(InsertCommand, batchStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
