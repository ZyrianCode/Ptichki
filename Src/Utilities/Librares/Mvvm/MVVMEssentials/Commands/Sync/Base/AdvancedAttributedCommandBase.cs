using System;
using System.Windows.Input;

namespace MVVMEssentials.Commands.Sync.Base
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class AdvancedAttributedCommandBase : Attribute, ICommand
    {
        /// <summary>
        ///  Вызывается, когда меняется возможность выполнения команды
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Метод, предоставляемый интерфейсом ICommand, проверяющий возможно ли выполнение комманды
        /// </summary>
        /// <param name="parameter"> - параметр команды. </param>
        /// <returns></returns>
        public virtual bool CanExecute(object? parameter) => true;

        /// <summary>
        /// Метод предоставляемый интерфейсом IComand и обеспечивающий выполнение команды
        /// </summary>
        /// <param name="parameter"> - параметр команды. </param>
        public abstract void Execute(object? parameter);

        public void OnCanExecutedChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
