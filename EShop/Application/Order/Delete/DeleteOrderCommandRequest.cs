using System;
using Application.Product.Delete;
using Domain.Orders;
using Domain.Product;
using MediatR;

namespace Application.Order.Delete
{
    public sealed record DeleteOrderCommandRequest : IRequest<DeleteOrderCommandResponse>
    {
        public OrderId Id { get; set; }
    }
}

