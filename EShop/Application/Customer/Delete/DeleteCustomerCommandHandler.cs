using System;
using Domain.Customer;
using MediatR;

namespace Application.Customer.Delete
{
	public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest , DeleteCustomerCommandResponse>
	{
        private readonly ICustomerRepository _customerRepository;

		public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
		{
            _customerRepository = customerRepository; 
		}

        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customerEmail = request.Email;

            var cusotmer = await _customerRepository.GetByEmailAsync(customerEmail);

            _customerRepository.Delete(cusotmer);

            var response = new DeleteCustomerCommandResponse
            {
                message = "İşlem başarılı"
            };

            _customerRepository.SaveChangeAsync();

            return response;
        }
    }
}

