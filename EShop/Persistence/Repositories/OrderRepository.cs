using System;
using Domain.Customer;
using Domain.Orders;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Order> GetByIdAsync(Guid orderId)
        {
            var order = await _context.Set<Order>()
                .Include(o => o.LineItems) // LineItems dahil et
                .FirstOrDefaultAsync(o => o.Id == new OrderId(orderId)); // Id ile eşleşen ilk kaydı getir

            return order;
        }


        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Set<Order>()
                .Include(o => o.LineItems) // LineItems'ları ilişkilendir
                .ToListAsync();
        }

    }
}

