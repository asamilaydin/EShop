using System;
using Application.Product.GetById;
using AutoMapper;

namespace Application.Product.GetById
{
	public class GetByIdProductMapper : Profile
	{
		public GetByIdProductMapper()
		{
            CreateMap<Domain.Product.Product, GetByIdProductQueryResponse>().ForMember(
                dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Price.Currency))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Price.Amount))
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku.Value));
        }
	}
}

