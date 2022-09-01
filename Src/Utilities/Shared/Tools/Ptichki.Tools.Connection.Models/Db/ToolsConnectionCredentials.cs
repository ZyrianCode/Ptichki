#nullable enable
namespace Ptichki.Tools.Connection.Models.Db
{
    public class ToolsConnectionCredentials 
    {
        public string? Server { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? ConnectionString { get; set; }

        public ToolsConnectionCredentials(string server, string user, string password)
        {
            Server = server;
            User = user;
            Password = password;
            ConnectionString = "server=" + Server +
                               ";user=" + User +
                               ";database=st;port=3306;password=" + Password;
        }

        public ToolsConnectionCredentials()
        {
            ConnectionString = "server=" + Server +
                               ";user=" + User +
                               ";database=st;port=3306;password=" + Password;
        }
    }
}