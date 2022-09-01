using Microsoft.EntityFrameworkCore;
using Ptichki.Domain.Models;

namespace Ptichki.Data.Contexts
{
    public class PtichkiDbContext : DbContext
    {
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<BirdType> BirdTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeesInDepartments> EmployeesInDepartments { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderComposition> OrderCompositions { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessTechnology> ProcessTechnologies { get; set; }
        public DbSet<ProductCatalog> Products { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Work> Works { get; set; }

        public PtichkiDbContext(DbContextOptions<PtichkiDbContext> options) : base(options)
        { }
    }
}
