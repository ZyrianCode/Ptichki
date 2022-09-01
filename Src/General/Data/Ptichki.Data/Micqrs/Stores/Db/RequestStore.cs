
using MICS.Helpers.Core.Abstractions;

namespace Ptichki.Data.Micqrs.Stores.Db
{
    /// <summary>
    /// Класс, предоставляющий компоненты, необходимые коннектору.
    /// </summary>
    public class RequestStore : IRequestStore
    {
        public string Request { get; set; }
    }
}
