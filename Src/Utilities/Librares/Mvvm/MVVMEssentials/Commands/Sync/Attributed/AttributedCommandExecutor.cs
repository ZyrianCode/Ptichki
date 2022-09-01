using System.Reflection;
using MVVMEssentials.Commands.Sync.Base;

namespace MVVMEssentials.Commands.Sync.Attributed
{
    public class AttributedCommandExecutor<TViewModel, TStoreType> : CommandBase
    {
        private readonly string _propertyToSet;

        public AttributedCommandExecutor(string propertyToSet)
        {
            _propertyToSet = propertyToSet;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var type = typeof(TViewModel);
            var incomingProperty = type.GetRuntimeProperty(parameter.ToString()!);
            var attribute = incomingProperty?.GetCustomAttribute<AttributedCommandBase>();

            var typeToSet = typeof(TStoreType);
            var propertyToSet = typeToSet.GetRuntimeProperty(_propertyToSet);
            propertyToSet?.SetValue(typeToSet, attribute?.ExecuteInnerCommand());
        }
    }
}
