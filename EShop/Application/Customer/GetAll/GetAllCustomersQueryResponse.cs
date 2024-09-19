using System;
using Domain.Customer;
using MediatR;
namespace Application.Customer.GetAll
{
    public class GetAllCustomersQueryResponse
    {
        public sealed record GetAllCustomersResponse(IEnumerable<CustomerModel> Customers);

        public sealed record CustomerModel
        {
            public CustomerId Id { get; init; }  // Güçlü tip yerine Guid
            public string Name { get; init; }
            public string Email { get; init; }
        }
    }
}


