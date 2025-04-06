using EShop.Application.Services;
using EShop.Domain.Repositories;
using EShop.Domain.Seeders;
using Microsoft.EntityFrameworkCore;
namespace EShopService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("EShopDB"));

            // Add services to the container.
            builder.Services.AddScoped<ICreditCardService, CreditCardService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                //var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                EShopSeeder.Seed(scope.ServiceProvider);//ywołanie metody seeda
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
