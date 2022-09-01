using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MICS.Helpers.Behaviors.Abstractions.Behavior;

namespace Ptichki.Data.Micqrs.Behaviors.Inserters
{
    /// <summary>
    /// Дефолтное поведение Inserter'а
    /// </summary>
    public class DefaultModeInserterBehavior : IBehavior
    {
        private readonly IList<object> _items;
        public IEnumerable<object> Items => _items;

        /// <summary>
        /// Дефолтное поведение Inserter'а
        /// </summary>
        public DefaultModeInserterBehavior()
        {
            _items = new List<object>();
        }

        public Task<IEnumerable<object>> Perform(SqlCommand command)
        {
            _items.Add(command.ExecuteNonQuery());
            return Task.FromResult<IEnumerable<object>>(_items);
        }
    }
}
