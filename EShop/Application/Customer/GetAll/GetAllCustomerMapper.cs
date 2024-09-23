using System;
using AutoMapper;
namespace Application.Customer.GetAll
{
	public class GetAllCustomerMapper : Profile
	{
		public GetAllCustomerMapper()
		{
			CreateMap<Domain.Customer.Customer, CustomerModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
            
		}
	}
}

