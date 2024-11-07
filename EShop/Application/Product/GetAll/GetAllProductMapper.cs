using System;
using AutoMapper;

namespace Application.Product.GetAll
{
	public class GetAllProductMapper : Profile
	{
		public GetAllProductMapper()
		{
			CreateMap<Domain.Product.Product, ProductModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
				.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Price.Currency))
				.ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Price.Amount))
				.ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku.Value));
        }
	}
}

