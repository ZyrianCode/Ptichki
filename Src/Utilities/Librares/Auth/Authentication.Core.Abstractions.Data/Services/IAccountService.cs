using System.Threading.Tasks;
using Authentication.Core.Models;

namespace Authentication.Core.Abstractions.Data.Services
{
    public interface IAccountService : IDataService<Account>
    {
        public Task<Account> GetByUsername(string username);
        public Task<Account> GetByEmail(string email);
    }
}
