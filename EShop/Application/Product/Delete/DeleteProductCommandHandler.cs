using System;
using Application.Customer.Delete;
using Domain.Customer;
using Domain.Product;
using MediatR;

namespace Application.Product.Delete
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
	{

        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id.Value);

            _productRepository.Delete(product);

            var response = new DeleteProductCommandResponse
            {
                Message = "İşlem başarılı",

                Success = true
            };
            _productRepository.SaveChangeAsync();

            return response;

        }
    }
}

