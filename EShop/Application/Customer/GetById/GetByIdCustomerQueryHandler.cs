using System;
using Domain.Customer;
using MediatR;
using AutoMapper;
namespace Application.Customer.GetById
{
	public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
	{
        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;

		public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
		{
            _customerRepository = customerRepository;

            _mapper = mapper;
        }

        public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id.Value);

            var customerRecords = _mapper.Map<GetByIdCustomerQueryResponse>(customer);

            return customerRecords;
            
        }
    }
}

