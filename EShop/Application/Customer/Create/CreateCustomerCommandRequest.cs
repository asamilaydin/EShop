using System;
using Domain.Customer;
using MediatR;

namespace Application.Customer.Create
{
	public sealed record CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
    {
       
        public string Email { get; init; }
        public string Name { get; init; }
    }
}

