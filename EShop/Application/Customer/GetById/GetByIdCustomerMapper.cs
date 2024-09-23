using System;
using AutoMapper;
namespace Application.Customer.GetById
{
	public class GetByIdCustomerMapper : Profile
	{
		public GetByIdCustomerMapper()
		{
			CreateMap<Domain.Customer.Customer, GetByIdCustomerQueryResponse>().ForMember(
				dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
		}
	}
}

