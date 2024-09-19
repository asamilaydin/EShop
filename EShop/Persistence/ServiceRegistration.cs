using System;
using Domain.Customer;
using Domain.Orders;
using Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection collection)
		{
			collection.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Port=5432;Database=EShopDB;Host=localhost;User Id=postgres;Password=12345"));

            collection.AddScoped<ICustomerRepository, CustomerRepository>();
            collection.AddScoped<IOrderRepository, OrderRepository>();
            collection.AddScoped<IProductRepository, ProductRepository>();

        }
	}
}

