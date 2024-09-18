using System;
using Domain.Customer;
using MediatR;
namespace Application.Customer.GetAll
{
	public class GetAllCustomersQueryResponse 
	{
        public sealed record GetAllCustomersResponse(IEnumerable<Customer> Customers);

        public sealed record Customer
        {
            public CustomerId Id { get; init; }
            public string Name { get; init; }
            public string Email { get; init; }
        }
    }
}

