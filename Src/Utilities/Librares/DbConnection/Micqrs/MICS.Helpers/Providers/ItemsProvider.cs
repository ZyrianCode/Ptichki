#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using MICS.Helpers.Abstractions.Connectors;
using MICS.Helpers.Abstractions.Providers;
using MICS.Helpers.Core.Abstractions;

namespace MICS.Helpers.Providers
{
    /// <summary>
    /// Поставщик данных из бд.
    /// <remarks> Поставляет данные из бд.
    ///           Паттерн: Provider(Strategy).
    /// </remarks>
    /// </summary>
    public class ItemsProvider : IItemsProvider
    {
        private readonly IConnectionCredentials? _connectionCredentials;
        private readonly IConnector? _connector;
        public IEnumerable<object>? Items { get; private set; }


        /// <summary>
        /// Поставщик данных из бд.
        /// <remarks> Поставляет данные из бд.
        ///           Паттерн: Provider(Strategy).
        /// </remarks>
        /// </summary>
        public ItemsProvider(IConnector connector,
                             IConnectionCredentials connectionCredentials
                            )
        {
            _connector = connector;
            _connectionCredentials = connectionCredentials;
        }

        public async Task<IEnumerable<object>?> GetAllItems()
        {
            Items = await _connector?.Connect(_connectionCredentials)!;

            return Items;
        }
    }
}
