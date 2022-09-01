﻿using System;

namespace MVVMEssentials.Commands.Sync.Base
{
    public class RelayCommand : CommandBase
    {
        private readonly Action<object> _execute; //Получает из разметки объект
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : this(parameters => execute(),
                canExecute is null ? null : parameters => canExecute()
            )
        {
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter) => 
            _canExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => 
            _execute(parameter);
    }
}
