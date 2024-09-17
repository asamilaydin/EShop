using System;
using Domain.Customer;

namespace Persistence.Repositories
{
	public class CustomerRepository : Repository<Customer> , ICustomerRepository
	{
		public CustomerRepository(ApplicationDbContext context) : base (context)
		{
		}
	}
}

