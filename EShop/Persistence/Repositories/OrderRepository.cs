using System;
using Domain.Customer;
using Domain.Orders;

namespace Persistence.Repositories
{
	public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

