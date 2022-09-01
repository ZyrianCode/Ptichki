using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ptichki.Data.Contexts;

namespace Ptichki.Data.IoC
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<PtichkiDbContext>(options =>
                {
                    var type = configuration["Type"];
                    switch (type)
                    {
                        case null: throw new InvalidOperationException(nameof(type) + "Db type undefined!");
                        default: throw new InvalidOperationException($"Type of connection {type} is not supported!");

                        case "MSSQL":
                            options.UseSqlServer(configuration.GetConnectionString(type));
                            break;

                        case "SQLite":
                            options.UseSqlite(configuration.GetConnectionString(type));
                            break;
                        case "InMemory":
                            options.UseInMemoryDatabase(configuration.GetConnectionString(type));
                            break;
                    }
                })
                .AddTransient<DbInitializer>()
                .AddRepositories();
    }
}
