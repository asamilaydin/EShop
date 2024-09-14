using System;
using Domain.Customer;

namespace Domain.Orders
{
    public class Order
	{

		private readonly HashSet<LineItem> _lineItems = new();

		public OrderId Id { get; set; }


		public CustomerId CustomerId  { get; set; }

		private Order()
		{
		}

		public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

		public static Order Create(Customer.Customer customer)
		{
			var order = new Order
			{
				Id = new OrderId(Guid.NewGuid()),
				CustomerId = customer.Id
			};
			return order;
		}

		public void Add(Product.Product product)
		{
			var lineItem = new LineItem(new LineItemId(Guid.NewGuid()), Id, product.Id, product.Price);
			_lineItems.Add(lineItem);
		}
	}
}

