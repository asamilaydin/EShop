using System.Collections.Generic;

namespace Application.Order.GetAll
{
    public sealed record GetAllOrderQueryResponse
    {
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();

        public class OrderDto
        {
            public Guid OrderId { get; set; }

            public Guid CustomerId { get; set; }

            public List<LineItemDto> LineItems { get; set; }

            public decimal TotalPrice { get; set; } // Toplam fiyat alanı
        }

        public class LineItemDto
        {
            public Guid LineItemId { get; set; }

            public Guid ProductId { get; set; }

            public decimal Price { get; set; } // Ürün fiyatı
        }
    }
}
