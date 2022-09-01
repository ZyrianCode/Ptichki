using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ptichki.Domain.Abstractions.ModelsBase;

namespace Ptichki.Domain.Abstractions.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Items { get; }
        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken cancellationToken = default);
        void Update(T item);
        Task UpdateAsync(T item,CancellationToken cancellationToken = default);
        T Delete(int id);
        Task<T> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}