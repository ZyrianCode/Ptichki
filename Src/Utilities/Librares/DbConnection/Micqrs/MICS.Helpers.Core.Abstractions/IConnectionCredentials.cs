
#nullable enable
namespace MICS.Helpers.Core.Abstractions
{
    public interface IConnectionCredentials
    {
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string? ConnectionString { get; set; }
    }
}
