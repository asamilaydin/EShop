using System;
using Application.Customer.GetById;
using AutoMapper;
using Domain.Customer;
using Domain.Product;
using MediatR;

namespace Application.Product.GetById
{
	public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
	{
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
		{
            _productRepository = productRepository;

            _mapper = mapper;
		}

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id.Value);

            var productRecords = _mapper.Map<GetByIdProductQueryResponse>(product);

            return productRecords;
        }
    }
}

