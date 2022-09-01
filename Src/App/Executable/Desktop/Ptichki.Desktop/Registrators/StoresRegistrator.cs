using Microsoft.Extensions.DependencyInjection;
using MVVMEssentials.Stores.Navigation;
using Ptichki.Data.Stores;
using Ptichki.Domain.Models;

namespace Ptichki.Desktop.Registrators
{
    public static class StoresRegistrator
    {
        public static IServiceCollection AddStores(this IServiceCollection services) => services
            .AddSingleton<PeopleStore>()
            .AddSingleton<GenericStore<Batch>>()
            .AddSingleton<GenericStore<Bird>>()
            .AddSingleton<GenericStore<BirdType>>()
            .AddSingleton<GenericStore<Customer>>()
            .AddSingleton<GenericStore<Department>>()
            .AddSingleton<GenericStore<EmployeesInDepartments>>()
            .AddSingleton<GenericStore<Employee>>()
            .AddSingleton<GenericStore<Equipment>>()
            .AddSingleton<GenericStore<Order>>()
            .AddSingleton<GenericStore<Parameter>>()
            .AddSingleton<GenericStore<Process>>()
            .AddSingleton<GenericStore<ProcessTechnology>>()
            .AddSingleton<GenericStore<ProductCatalog>>()
            .AddSingleton<GenericStore<Stage>>()
            .AddSingleton<GenericStore<Work>>()

            .AddSingleton<NavigationStore>()
            .AddSingleton<ModalNavigationStore>();
    }
}
