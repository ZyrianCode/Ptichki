using System.Threading.Tasks;
using MICS.Helpers.Abstractions.Providers;

namespace MICS.Helpers.Abstractions.Loaders
{
    /// <summary>
    /// Интерфейс загрузчика.
    /// <remarks> Задаёт контракт загрузчику. </remarks>
    /// </summary>
    public interface ILoader : ICollectionProvider
    {
        /// <summary>
        /// Метод, начинающий загрузку данных из бд.
        /// </summary>
        /// <returns> Задача. </returns>
        public Task Load();
    }
}
