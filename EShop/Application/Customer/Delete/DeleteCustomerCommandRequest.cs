using System;
using MediatR;	
namespace Application.Customer.Delete
{
	public sealed record DeleteCustomerCommandRequest : IRequest<DeleteCustomerCommandResponse>
	{
		public string Email { get; init; }
	}
}

