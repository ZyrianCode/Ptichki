#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MICS.Helpers.Abstractions.Connectors;
using MICS.Helpers.Abstractions.Utilities;
using MICS.Helpers.Behaviors.Abstractions.Behavior;
using MICS.Helpers.Core.Abstractions;


namespace MICS.Helpers.Connectors
{
    /// <summary>
    /// Коннектор.
    /// <remarks> Занимается подключением к базе данных.
    ///           Требует подключенных утилит в конструктор.
    ///           Паттерн: MICS
    /// </remarks>
    /// </summary>
    public sealed class Connector : IConnector
    {
        private readonly IUtility? _utility;
        private readonly IBehavior _utilityBehavior;
        private readonly string? _request;
        private SqlConnection? _connection;

        private readonly List<object> _items;
        public IEnumerable<object> Items => _items;
        
        public Connector(IUtility utility,
                         IBehavior utilityBehavior,
                         IRequestStore? requestStore)
        {
            _utility = utility;
            _items = new List<object>();
            _utilityBehavior = utilityBehavior;
            _request = requestStore?.Request;
        }


        public async Task<IEnumerable<object>?> Connect(IConnectionCredentials? connectionCredentials)
        {
            var connectionString = connectionCredentials?.ConnectionString;

            var connection = new SqlConnection(connectionString);
            _connection = connection;

            return await OpenConnection();
        }

        public async Task<IEnumerable<object>?> OpenConnection()
        {
            try
            {
                Console.WriteLine("Connecting to MySQL...");

                await _connection?.OpenAsync()!;
                var command = new SqlCommand(_request, _connection);
                _utility?.SetDataComponents(command);
                var items = await _utility?.PerformTask(_utilityBehavior)!;

                _items.Clear();
                _items.AddRange(items);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            await _connection.CloseAsync();

            Console.WriteLine("Done.");

            return Items;
        }
    }
}
