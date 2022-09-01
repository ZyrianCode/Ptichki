using System.Collections.Generic;

namespace MICS.Helpers.Abstractions.Providers
{
    /// <summary>
    /// Интерфейс поставляющий свойство Items.
    /// Позволяет не возвращать конкретный тип коллекции в методах с возвращаемым типом Task
    /// </summary>
    public interface ICollectionProvider
    {
        /// <summary>
        /// Коллекция предметов, которая будет храниться в загрузчике.
        /// </summary>
        public IEnumerable<object>? Items { get; }
    }
}
