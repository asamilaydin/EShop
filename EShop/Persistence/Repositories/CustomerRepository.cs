using System;
using Domain.Customer;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
	public class CustomerRepository : Repository<Customer> , ICustomerRepository
	{
		public CustomerRepository(ApplicationDbContext context) : base (context)
		{
            

        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Set<Customer>().FindAsync(new CustomerId(id));
        }


    }
}

