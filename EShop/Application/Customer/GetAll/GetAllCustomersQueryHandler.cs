using Application.Customer.GetAll;
using Domain.Customer; 
using MediatR;
using static Application.Customer.GetAll.GetAllCustomersQueryResponse;

namespace Application.QueryHandlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, GetAllCustomersResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetAllCustomersResponse> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            var customerRecords = customers.Select(c => new Domain.Customer.Customer
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email
                
            }).ToList();

            return new GetAllCustomersResponse(customerRecords);
        }
    }
}
