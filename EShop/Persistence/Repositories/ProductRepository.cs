using System;
using Domain.Customer;
using Domain.Product;

namespace Persistence.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

