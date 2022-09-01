using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.Core.Abstractions.Data.Services;
using Authentication.Core.Models;
using Ptichki.Data.Authentication.Repositories;
using Ptichki.Data.Services;

namespace Ptichki.Data.Authentication.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService()
        {
            _nonQueryDataService = new NonQueryDataService<Account>();
        }

        public Task<IEnumerable<Account>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Account> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Create(Account entity)
        {
            //throw new NotImplementedException();
            BDSimulator.Accounts.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<Account> Update(int id, Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByEmail(string email)
        {
            //return BDSimulator.Accounts.Include(a => a.AccountHolder)
            //.FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
            
            //throw new NotImplementedException();
            return Task.FromResult(BDSimulator.Accounts.Find(a => a.AccountHolder.Email == email));
        }
    }
}
