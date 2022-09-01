using Microsoft.Extensions.DependencyInjection;
using MVVMEssentials.ViewModels;

namespace Ptichki.Desktop.Registrators
{
    public static class WindowsRegistrator
    {
        public static IServiceCollection AddWindows(this IServiceCollection services) => services
            .AddSingleton(s => new MainWindow
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
    }
}
