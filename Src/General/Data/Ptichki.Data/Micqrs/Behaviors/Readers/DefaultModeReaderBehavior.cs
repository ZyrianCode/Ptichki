using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MICS.Helpers.Behaviors.Abstractions.Behavior;

namespace Ptichki.Data.Micqrs.Behaviors.Readers
{
    /// <summary>
    /// Дефолтное поведение для читателя.
    /// <remarks> Паттерн: Укороченная стратегия. </remarks>
    /// </summary>
    public class DefaultModeReaderBehavior : IBehavior
    {
        private SqlDataReader _reader;
        private readonly IList<object> _items;
        public IEnumerable<object> Items => _items;

        /// <summary>
        /// Дефолтное поведение для читателя.
        /// <remarks> Паттерн: Укороченная стратегия. </remarks>
        /// </summary>
        public DefaultModeReaderBehavior()
        {
            _items = new List<object>();
        }

        public async Task<IEnumerable<object>> Perform(SqlCommand command)
        {
            _reader = await command.ExecuteReaderAsync();

            const int index = 0;

            _items.Clear();

            while (_reader.Read())
            {
                _items.Add(_reader[index].ToString());
            }
            _reader.Close();
            return Items;
        }
    }
}
