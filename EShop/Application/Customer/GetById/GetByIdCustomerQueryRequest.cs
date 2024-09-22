using System;
using Domain.Customer;
using MediatR;
namespace Application.Customer.GetById
{
	public sealed record GetByIdCustomerQueryRequest : IRequest<GetByIdCustomerQueryResponse>
	{
		public CustomerId Id { get; set; }
	}
}

