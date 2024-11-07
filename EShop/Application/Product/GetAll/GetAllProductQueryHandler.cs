using System;
using Application.Customer.GetAll;
using AutoMapper;
using Domain.Product;
using MediatR;

namespace Application.Product.GetAll
{
	public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
	{
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

		public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
		{
            _productRepository = productRepository;

            _mapper = mapper;
		}

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            var productsRecords = _mapper.Map<IEnumerable<ProductModel>>(products);

            var allRecords = new GetAllProductQueryResponse(productsRecords);

            return allRecords;

        }
    }
}

