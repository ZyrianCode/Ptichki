using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.Console;

namespace Ptichki.Data.Services
{
    internal class ConnectionService
    {
        public async Task Connect(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                await connection.OpenAsync();
                WriteLine("Подключение открыто");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    // закрываем подключение
                    await connection.CloseAsync();
                    Console.WriteLine("Подключение закрыто...");
                }

                WriteLine("Подключение закрыто...");
                Read();
            }
        }
    }
}
