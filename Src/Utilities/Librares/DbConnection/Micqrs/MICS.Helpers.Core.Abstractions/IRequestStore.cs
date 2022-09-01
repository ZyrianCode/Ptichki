
#nullable enable
namespace MICS.Helpers.Core.Abstractions
{
    /// <summary>
    /// Интерфейс, предоставляющий компоненты, необходимые коннектору.
    /// </summary>
    public interface IRequestStore
    {
        public string? Request { get; set; }
    }
}
