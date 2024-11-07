using System;
using Domain.Product;
using MediatR;

namespace Application.Product.Delete
{
	public sealed record DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
	{
		public ProductId Id { get; set; }
	}
}

 