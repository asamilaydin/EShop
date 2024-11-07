using System;
using Application.Product.GetById;
using Domain.Product;
using MediatR;

namespace Application.Product.GetById
{
    public sealed record GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public ProductId Id { get; set; }
    }
}

