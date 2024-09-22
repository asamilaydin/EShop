using System;
namespace Application.Customer.Delete
{
	public sealed record DeleteCustomerCommandResponse 
	{
		public string message { get; init; }
	}
}

