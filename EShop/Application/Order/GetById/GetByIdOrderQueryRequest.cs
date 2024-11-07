using System;
using Application.Order.GetAll;
using Domain.Orders;
using MediatR;

namespace Application.Order.GetById
{
    public sealed record GetByIdOrderQueryRequest : IRequest<GetByIdOrderQueryResponse>
    {
        public OrderId Id { get; set; }
    }
}

