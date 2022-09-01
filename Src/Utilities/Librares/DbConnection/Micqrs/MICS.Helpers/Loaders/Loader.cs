#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MICS.Helpers.Abstractions.Loaders;
using MICS.Helpers.Abstractions.Providers;

namespace MICS.Helpers.Loaders
{
    /// <summary>
    /// Загрузчик данных из бд.
    /// <remarks> Занимается загрузкой данных из бд. </remarks>
    /// </summary>
    public sealed class Loader : ILoader
    {
        private readonly List<object> _items;
        private readonly IItemsProvider _itemsProvider;
        private Lazy<Task> _lazyInitialization;
        public IEnumerable<object> Items => _items;

        /// <summary>
        /// Загрузчик данных из бд.
        /// <remarks> Занимается загрузкой данных из бд. </remarks>
        /// </summary>
        public Loader(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;
            _lazyInitialization = new Lazy<Task>(Initialize);
            _items = new List<object>();
        }

        public async Task Load()
        {
            try
            {
                await _lazyInitialization.Value;
            }
            catch (Exception)
            {
                _lazyInitialization = new Lazy<Task>(Initialize);
                throw;
            }
        }
        private async Task Initialize()
        {
            var items = await _itemsProvider.GetAllItems();
            _items.Clear();
            _items.AddRange(items!);
        }
    }
}
