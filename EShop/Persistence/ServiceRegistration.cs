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
		public static void AddPersistenceService(this IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Port=5432;Database=EShopDB;Host=localhost;User Id=postgres;Password=12345"));

			services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }
	}
}

