#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MICS.Helpers.Abstractions.Providers
{
    /// <summary>
    /// Интерфейс поставщика данных из бд.
    /// <remarks> Задаёт контракт поставщику данных.
    ///           Паттерн: Provider(Strategy)
    /// </remarks>
    /// </summary>
    public interface IItemsProvider : ICollectionProvider
    {
        /// <summary>
        /// Метод, вытаскивающий данные из бд.
        /// </summary>
        /// <returns> <see cref="IEnumerable{T}"/> - перечисление </returns>
        public Task<IEnumerable<object>?> GetAllItems();
    }
}
