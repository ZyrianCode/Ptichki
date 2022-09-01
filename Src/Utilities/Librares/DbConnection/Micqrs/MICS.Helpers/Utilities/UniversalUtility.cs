using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MICS.Helpers.Abstractions.Utilities;
using MICS.Helpers.Behaviors.Abstractions.Behavior;

namespace MICS.Helpers.Utilities
{
    public class UniversalUtility : IUtility
    {
        private readonly List<object> _items;
        private SqlCommand _command;
        public IEnumerable<object> Items => _items;

        public void SetDataComponents(SqlCommand? command)
        {
            _command = command;
        }

        public async Task<IEnumerable<object>?> PerformTask(IBehavior utilityBehavior)
        {
            var items = await utilityBehavior?.Perform(_command)!;

            _items.Clear();
            _items.AddRange(items);

            return Items;
        }
    }
}
