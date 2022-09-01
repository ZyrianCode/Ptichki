using Microsoft.Extensions.DependencyInjection;
using Ptichki.Data.Repositories;
using Ptichki.Domain.Abstractions.Repositories;
using Ptichki.Domain.Models;

namespace Ptichki.Data.IoC
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Batch>, BatchesRepository>()
            .AddTransient<IRepository<Bird>, BirdsRepository>()
            .AddTransient<IRepository<BirdType>, DbRepository<BirdType>>()
            .AddTransient<IRepository<Customer>, DbRepository<Customer>>()
            .AddTransient<IRepository<Department>, DbRepository<Department>>()
            .AddTransient<IRepository<Employee>, DbRepository<Employee>>()
            .AddTransient<IRepository<EmployeesInDepartments>, EmployeesInDepartmentsRepository>()
            .AddTransient<IRepository<Equipment>, DbRepository<Equipment>>()
            .AddTransient<IRepository<Order>, OrdersRepository>()
            .AddTransient<IRepository<OrderComposition>, OrderCompositionsRepository>()
            .AddTransient<IRepository<Parameter>, DbRepository<Parameter>>()
            .AddTransient<IRepository<Process>, ProcessRepository>()
            .AddTransient<IRepository<ProcessTechnology>, ProcessTechnologiesRepository>()
            .AddTransient<IRepository<ProductCatalog>, DbRepository<ProductCatalog>>()
            .AddTransient<IRepository<Stage>, DbRepository<Stage>>()
            .AddTransient<IRepository<Work>, WorksRepository>()
            .AddTransient<IRepository<Todo>, DbRepository<Todo>>();
    }
}
