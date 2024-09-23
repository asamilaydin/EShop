using Application.Customer.GetAll;
using AutoMapper;
using Domain.Customer;
using MediatR;
using static Application.Customer.GetAll.GetAllCustomersResponse;

namespace Application.QueryHandlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, GetAllCustomersResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<GetAllCustomersResponse> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();


            var customerRecords = _mapper.Map<IEnumerable<CustomerModel>>(customers);
            var allRecords = new GetAllCustomersResponse(customerRecords);

            return allRecords;
        }
    }
}
