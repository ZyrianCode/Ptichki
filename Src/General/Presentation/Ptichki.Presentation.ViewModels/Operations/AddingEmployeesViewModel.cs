using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MICS.Helpers.Core.Abstractions;
using MVVMEssentials.Commands.Sync.Base;
using MVVMEssentials.Commands.Sync.Navigation;
using MVVMEssentials.Services.Abstract;
using MVVMEssentials.ViewModels;
using Ptichki.Application.Micqrs.Db;
using Ptichki.Data.Micqrs.Behaviors.Inserters;
using Ptichki.Data.Micqrs.Stores.Db;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;
using Ptichki.Presentation.Commands.Adding;
using Ptichki.Presentation.ViewModels.Dto;

namespace Ptichki.Presentation.ViewModels.Operations
{
    public class AddingEmployeesViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();

        public IEnumerable<Employee> Employees
        {
            get => _employees;
            set => _employees = (ObservableCollection<Employee>)value;
        }

        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _patronymic;
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        private DateTime _dateOfBirthday;
        public DateTime DateOfBirthday
        {
            get => _dateOfBirthday;
            set
            {
                _dateOfBirthday = value;
                OnPropertyChanged(nameof(DateOfBirthday));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _passportNumber;
        public string PassportNumber
        {
            get => _passportNumber;
            set
            {
                _passportNumber = value;
                OnPropertyChanged(nameof(PassportNumber));
            }
        }

        private string _passportSerial;
        public string PassportSerial
        {
            get => _passportSerial;
            set
            {
                _passportSerial = value;
                OnPropertyChanged(nameof(PassportSerial));
            }
        }


        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand InsertCommand { get; }
        public ICommand AddItemCommand { get; }

        public AddingEmployeesViewModel(GenericStore<Employee> employeesStore, INavigationService closeNavigationService)
        {
            IRequestStore requestStore = new RequestStore();
            requestStore.Request = "";
            //_employees = new ObservableCollection<Employee>();
            InsertCommand = new InsertCommand(this, requestStore, new DefaultModeInserterBehavior());
            SubmitCommand = new AddingGenericCommand<Employee>(InsertCommand, employeesStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
            AddItemCommand = new RelayCommand(AddItem);
        }

        public void AddItem() => _employees.Add(new Employee());
    }
}
