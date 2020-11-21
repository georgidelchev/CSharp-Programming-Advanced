using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Core.Contracts;
using ProductCatalog.Core.Services;
using ProductCatalog.Infrastructure.Data;
using ProductCatalog.Infrastructure.Data.Common;
using ProductCatalog.Pages;

namespace ProductCatalog.Utilities
{
    public static class DependancyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IRepository, Repository>();
            services.AddSingleton<Application>();
            services.AddScoped<Menu>();
            services.AddScoped<ProductPage>();
            services.AddScoped<IProductService, ProductService>();

            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;"));

            return services
                .BuildServiceProvider();
        }
    } 
}
