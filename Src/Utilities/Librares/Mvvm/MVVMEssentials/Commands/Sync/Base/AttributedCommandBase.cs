using System;

namespace MVVMEssentials.Commands.Sync.Base
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class AttributedCommandBase : Attribute
    {
        public abstract string ExecuteInnerCommand();
    }
}
