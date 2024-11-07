using System;
using Application.Product.GetAll;
using MediatR;

namespace Application.Order.GetAll
{
    public sealed record GetAllOrderQueryRequest : IRequest<List<GetAllOrderQueryResponse.OrderDto>>
    {

    }
}

