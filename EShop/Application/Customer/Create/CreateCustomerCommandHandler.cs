using System;
using AutoMapper;
using Domain.Customer;
using MediatR;
namespace Application.Customer.Create
{
	public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
	{

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

		public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper) 
		{
            _customerRepository = customerRepository;
            _mapper = mapper;


        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {

             var customerId =  Guid.NewGuid();
            var newCustomer = _mapper.Map<Domain.Customer.Customer>(request);


            _customerRepository.Insert(newCustomer);
            _customerRepository.SaveChangeAsync();

            var response = new CreateCustomerCommandResponse
            {
                Success = true,
                Message = "Customer successfully created."
            };
            return await Task.FromResult(response);

        }
    }
}

