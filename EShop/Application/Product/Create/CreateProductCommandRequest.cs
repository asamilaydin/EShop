using System;
using Domain.Product;
using MediatR;

namespace Application.Product.Create
{
	public sealed record CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
	{
        public string Name { get; set; }

        public Money Price { get; set; }

        public string SkuValue { get; set; } 

    }
}

