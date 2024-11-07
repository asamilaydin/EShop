using System;
using Domain.Customer;
using MediatR;
using Domain.Orders;
using Domain.Product;

namespace Application.Order.Create
{
	public sealed record CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
	{
		public CustomerId customerId { get; set; }

		public List<OrderLineItem> lineItem { get; set; }

		public class OrderLineItem
		{
			public Guid productId{ get; set; }

        }

	}
}

