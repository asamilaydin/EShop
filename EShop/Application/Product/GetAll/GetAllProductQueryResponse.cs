using System;
using Application.Customer.GetAll;
using Domain.Product;

namespace Application.Product.GetAll
{

    public sealed record GetAllProductQueryResponse(IEnumerable<ProductModel> Products);

    public class ProductModel //IEnumarable ekle.
	{
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Sku { get; set; } 
    }
}

