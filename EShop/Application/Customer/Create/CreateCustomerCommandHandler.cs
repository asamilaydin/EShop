using System;
using Domain.Customer;
using MediatR;
namespace Application.Customer.Create
{
	public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
	{

        private readonly ICustomerRepository _customerRepository;
		public CreateCustomerCommandHandler(ICustomerRepository customerRepository) 
		{
            _customerRepository = customerRepository;

        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {

             var customerId =  Guid.NewGuid();
            var newCustomer = new Domain.Customer.Customer
            {
                Id = new CustomerId(customerId),      // ID doğrudan request'ten alınır
                Name = request.Name,  // İsim doğrudan request'ten alınır
                Email = request.Email // Email doğrudan request'ten alınır
            };

            // Repository aracılığıyla veritabanına eklenir
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

