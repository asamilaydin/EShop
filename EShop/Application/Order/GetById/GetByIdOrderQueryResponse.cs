using System;
using static Application.Order.GetAll.GetAllOrderQueryResponse;

namespace Application.Order.GetById
{
	public sealed record GetByIdOrderQueryResponse
	{
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public List<LineItemDto> LineItems { get; set; }

        public decimal TotalPrice { get; set; } // Toplam fiyat alanı

        public sealed record LineItemDto
        {
            public Guid LineItemId { get; set; }

            public Guid ProductId { get; set; }

            public decimal Price { get; set; } // Ürün fiyatı
        }
    }

    
}

