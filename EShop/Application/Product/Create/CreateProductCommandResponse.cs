using System;

namespace Application.Product.Create
{
	public sealed record CreateProductCommandResponse
	{
        public bool Success { get; init; }

        public string Message { get; init; }
    }
}

