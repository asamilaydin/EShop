using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Persistence
{
	public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder = new();
			dbContextOptionsBuilder.UseNpgsql("Port=5432;Database=EShopDB;Host=localhost;User Id=postgres;Password=12345");

			return new(dbContextOptionsBuilder.Options);

		}
	}
}

