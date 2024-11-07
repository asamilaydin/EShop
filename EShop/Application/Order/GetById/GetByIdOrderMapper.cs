using System;
using Application.Order.GetAll;
using AutoMapper;
using Domain.Orders;

namespace Application.Order.GetById
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Orders.Order, GetByIdOrderQueryResponse>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId.Value))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src =>
                    src.LineItems.Sum(item => item.Price.Amount))) // Toplam fiyat hesaplanıyor
                .ForMember(dest => dest.LineItems, opt => opt.MapFrom(src => src.LineItems));

            CreateMap<LineItem, GetByIdOrderQueryResponse.LineItemDto>()
                .ForMember(dest => dest.LineItemId, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId.Value))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Amount));
        }
    }
}



