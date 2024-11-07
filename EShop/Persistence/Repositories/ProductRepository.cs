using System;
using Domain.Customer;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Product> GetByIdAsync(Guid productId)
        {
            return await _context.Set<Product>().FindAsync(new ProductId(productId)); // Burada productId.Value kullanıyoruz // sorun olur mu ??
        }

    }
}

