using System;
using Domain.Customer;
using MediatR;
namespace Application.Customer.GetById
{
	public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
	{
        private readonly ICustomerRepository _customerRepository;
		public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository)
		{
            _customerRepository = customerRepository;
        }

        public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id.Value);
            var customerRecords = new GetByIdCustomerQueryResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email

            };
            return customerRecords;
            
        }
    }
}

