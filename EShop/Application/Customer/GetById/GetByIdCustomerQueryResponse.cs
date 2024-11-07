using System;
using Domain.Customer;

namespace Application.Customer.GetById
{
	public sealed record GetByIdCustomerQueryResponse
	{
        public CustomerId Id { get; init; }
        
        public string Name { get; init; }

        public string Email { get; init; }
    }
}

