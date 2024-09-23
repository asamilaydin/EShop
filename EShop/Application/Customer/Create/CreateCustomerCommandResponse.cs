using System;
namespace Application.Customer.Create
{
	public sealed record CreateCustomerCommandResponse
	{
        public bool Success { get; init; } 
        public string Message { get; init; } 

    }
}

