#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using MICS.Helpers.Abstractions.Providers;
using MICS.Helpers.Core.Abstractions;

namespace MICS.Helpers.Abstractions.Connectors
{
    /// <summary>
    /// Интерфейс коннектора.
    /// <remarks> Задаёт контракт коннектору.
    ///           Паттерн: Strategy
    /// </remarks>
    /// </summary>
    public interface IConnector : ICollectionProvider
    {
        /// <summary>
        /// Метод, доступный коннектору.
        /// </summary>
        /// <remarks> Занимается подключением к базе. Связывает с космосом. </remarks>
        /// <param name="connectionCredentials"> - блок информации, предоставляемый коннектору. </param>
        /// <returns> Перечисление объектов. </returns>
        public Task<IEnumerable<object>?> Connect(IConnectionCredentials? connectionCredentials);
    }
}
