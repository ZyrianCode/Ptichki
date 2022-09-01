using System;
using Ptichki.Domain.Abstractions.ModelsBase;
using Ptichki.Domain.Abstractions.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ptichki.Data.Contexts;
using Ptichki.Domain.Models;

namespace Ptichki.Data.Repositories
{
    internal class DbRepository<T> : IRepository<T> where T : DomainObject, new()
    {
        private readonly PtichkiDbContext _dbContext;
        private readonly DbSet<T> _dbSetter;
        public bool AutoSaveChanges { get; set; } = true;
        public DbRepository(PtichkiDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSetter = dbContext.Set<T>();
        }

        public virtual IQueryable<T> Items => _dbSetter;
        public T Get(int id) => 
            Items.SingleOrDefault(item => item.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken cancellationToken = default) => await Items
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        

        public T Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _dbContext.Entry(item).State = EntityState.Added;

            if (AutoSaveChanges)
            {
                _dbContext.SaveChanges();
            }
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken cancellationToken = default)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _dbContext.Entry(item).State = EntityState.Added;

            if (AutoSaveChanges)
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            return item;
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _dbContext.Entry(item).State = EntityState.Modified;

            if (AutoSaveChanges)
            {
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateAsync(T item, CancellationToken cancellationToken = default)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _dbContext.Entry(item).State = EntityState.Modified;

            if (AutoSaveChanges)
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public T Delete(int id)
        {
            var deletingObject = new T { Id = id };
            _dbContext.Remove(deletingObject);
            
            if (AutoSaveChanges)
            {
                _dbContext.SaveChanges();
            }

            return deletingObject;
        }

        public async Task<T> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var deletingObject = new T { Id = id };
            _dbContext.Remove(deletingObject);

            if (AutoSaveChanges)
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            return deletingObject;
        }
    }

    internal class BatchesRepository : DbRepository<Batch>
    {
        public override IQueryable<Batch> Items => base.Items
            .Include(item => item.Catalog);

        public BatchesRepository(PtichkiDbContext dbContext) : base(dbContext)
        {
        }
    }

    internal class BirdsRepository : DbRepository<Bird>
    {
        public override IQueryable<Bird> Items => base.Items
            .Include(item => item.BirdTypes);

        public BirdsRepository(PtichkiDbContext dbContext) : base(dbContext)
        {
        }
    }

    internal class EmployeesInDepartmentsRepository : DbRepository<EmployeesInDepartments>
    {
        public override IQueryable<EmployeesInDepartments> Items => base.Items
            .Include(item => item.Employee)
            .Include(item => item.Department);

        public EmployeesInDepartmentsRepository(PtichkiDbContext dbContext) : base(dbContext)
        {
        }
    }

    internal class OrdersRepository : DbRepository<Order>
    {
        public override IQueryable<Order> Items => base.Items
            .Include(item => item.Customer);

        public OrdersRepository(PtichkiDbContext dbContext) : base(dbContext)
        {
        }
    }

    internal class OrderCompositionsRepository : DbRepository<OrderComposition>
    {
        public override IQueryable<OrderComposition> Items => base.Items
            .Include(item => item.Batch)
            .Include(item => item.Order);

        public OrderCompositionsRepository(PtichkiDbContext dbContext) : base(dbContext)
        {
        }
    }


    internal class ProcessRepository : DbRepository<Process>
    {
        public override IQueryable<Process> Items => base.Items
            .Include(item => item.Stage);

        public ProcessRepository(PtichkiDbContext dbContext) : base(dbContext)
        {
        }
    }

    internal class ProcessTechnologiesRepository : DbRepository<ProcessTechnology>
    {
        public override IQueryable<ProcessTechnology> Items => base.Items
            .Include(item => item.ProductCatalog)
            .Include(item => item.Process)
            .Include(item => item.Equipment)
            .Include(item => item.Parameter);

        public ProcessTechnologiesRepository(PtichkiDbContext dbContext) : base(dbContext)
        {
        }
    }

    internal class WorksRepository : DbRepository<Work>
    {
        public override IQueryable<Work> Items => base.Items
            .Include(item => item.Batch)
            .Include(item => item.Employee)
            .Include(item => item.Process)
            .Include(item => item.Equipment)
            .Include(item => item.Bird);

        public WorksRepository(PtichkiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
