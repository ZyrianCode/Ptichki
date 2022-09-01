using System.Threading.Tasks;
using Authentication.Core.Models;

namespace Authentication.Core.Abstractions.Services
{
    public interface IAccountCreationService
    {
        public Task<Account> CreateAccount(string email, string username, string password);
    }
}
