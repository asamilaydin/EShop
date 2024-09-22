using System;
using System.Linq.Expressions;
using Domain.Repositories;

namespace Domain.Customer
{
	public interface ICustomerRepository : IRepository<Customer>
	{
        Task<Customer> GetByIdAsync(Guid id);
    }

}

