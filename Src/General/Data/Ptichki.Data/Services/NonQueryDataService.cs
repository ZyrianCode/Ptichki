using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ptichki.Domain.Abstractions.Services;

namespace Ptichki.Data.Services
{
    public class NonQueryDataService<T> : IDataService<T>
    {
        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
