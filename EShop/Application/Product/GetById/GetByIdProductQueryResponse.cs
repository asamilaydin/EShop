using System;
using Domain.Product;

namespace Application.Product.GetById
{
	public sealed record GetByIdProductQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Sku { get; set; }

    }
	
}

