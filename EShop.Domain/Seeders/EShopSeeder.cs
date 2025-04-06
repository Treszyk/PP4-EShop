using EShop.Domain.Models;
using EShop.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EShop.Domain.Seeders
{
    public static class EShopSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            if (context.Products.Any()) return;

            var products = new[]
            {
                new Product { Name = "Laptop", Ean = "1234567890123", Price = 3500.00, Stock = 10, Sku = "LAP123" },
                new Product { Name = "Smartphone", Ean = "9876543210987", Price = 2500.00, Stock = 20, Sku = "SMT456" },
                new Product { Name = "Vacuum Cleaner", Ean = "5678901234567", Price = 500.00, Stock = 5, Sku = "VAC789" }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
