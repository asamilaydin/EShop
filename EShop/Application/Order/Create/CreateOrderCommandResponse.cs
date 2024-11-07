using System;
using Domain.Customer;
using Domain.Orders;

namespace Application.Order.Create
{
	public sealed record CreateOrderCommandResponse
	{

        public OrderId Id { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public List<LineItem> LineItems { get; set; }

    }
}

