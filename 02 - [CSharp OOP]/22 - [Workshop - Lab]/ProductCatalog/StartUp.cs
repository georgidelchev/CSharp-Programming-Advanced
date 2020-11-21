using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCatalog.Infrastructure.Data;
using ProductCatalog.Utilities;

namespace ProductCatalog
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = DependancyResolver.GetServiceProvider();

            var app = serviceProvider.GetService<Application>();

            using (serviceProvider.CreateScope())
            {
                app.Run(args);
            }

            //CreateHostBuilder(args)
            //    .Build()
            //    .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                    .AddDbContext<ApplicationDbContext>(o => o.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;"));
                });
        }
    }
}
