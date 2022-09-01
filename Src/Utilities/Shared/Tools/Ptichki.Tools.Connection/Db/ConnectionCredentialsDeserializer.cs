using Ptichki.Tools.Connection.Models.Db;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ptichki.Tools.Connection.Db
{
    public static class ConnectionCredentialsDeserializer
    {
        private static string _url;
        private const int CountToRead = 4;
        public static Task<ToolsConnectionCredentials> DeserializeInfo(string url)
        {
            _url = url;
            var list = new List<string>();
            using var reader = new StreamReader(_url);
            var index = 0;
            string line;

            for (var count = 0; count != CountToRead; count++)
            {
                line = reader.ReadLine();
                list.Add(line);
            }

            reader.Close();

            var server = list[index];
            var user = list[++index];
            var password = list[++index];

            return Task.FromResult(new ToolsConnectionCredentials(server, user, password));
        }
    }
}
