using AutoMapper;
using Domain.Orders;
using System.Linq;

namespace Application.Order.GetAll
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Orders.Order, GetAllOrderQueryResponse.OrderDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId.Value))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src =>
                    src.LineItems.Sum(item => item.Price.Amount))) // Toplam fiyat hesaplanıyor
                .ForMember(dest => dest.LineItems, opt => opt.MapFrom(src => src.LineItems));

            CreateMap<LineItem, GetAllOrderQueryResponse.LineItemDto>()
                .ForMember(dest => dest.LineItemId, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId.Value))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Amount));
        }
    }
}
