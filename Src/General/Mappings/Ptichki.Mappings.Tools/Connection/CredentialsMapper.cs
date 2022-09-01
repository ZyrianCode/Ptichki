using Ptichki.Data.Models.Db;
using Ptichki.Tools.Connection.Models.Db;

namespace Ptichki.Mappings.Tools.Connection
{
    public static class CredentialsMapper
    {
        public static DbConnectionCredentials ToData(this ToolsConnectionCredentials toolsConnectionCredentials) =>
            new()
            {
                Server = toolsConnectionCredentials.Server,
                User = toolsConnectionCredentials.User,
                Password = toolsConnectionCredentials.Password
            };

        public static ToolsConnectionCredentials ToTools(this DbConnectionCredentials dbConnectionCredentials) =>
            new()
            {
                Server = dbConnectionCredentials.Server,
                User = dbConnectionCredentials.User,
                Password = dbConnectionCredentials.Password
            };
    }
}
