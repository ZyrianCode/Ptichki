using System;
using Microsoft.Extensions.Hosting;

namespace Ptichki.Desktop
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var app = new App();
            app.Run();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices(App.ConfigureServices);
    }
}
