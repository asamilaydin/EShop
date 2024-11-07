using System;
using MediatR;

namespace Application.Product.GetAll
{
	public sealed record GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
	{
		
	}
}

