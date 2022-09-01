
using MICS.Helpers.Core.Abstractions;

namespace Ptichki.Data.Models.Db
{
    public class DbConnectionCredentials : IConnectionCredentials
    {
        public string? Server { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? ConnectionString { get; set; }

        public DbConnectionCredentials(string server, string user, string password)
        {
            Server = server;
            User = user;
            Password = password;
            ConnectionString = "server=" + Server +
                               ";user=" + User +
                               ";database=st;port=3306;password=" + Password;
        }

        public DbConnectionCredentials()
        {
            ConnectionString = "server=" + Server +
                               ";user=" + User +
                               ";database=st;port=3306;password=" + Password;
        }
    }
}
