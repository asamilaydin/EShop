using System;
using AutoMapper;
using Domain.Customer;
namespace Application.Customer.Create
{
	public class CreateCustomerMapper : Profile
	{
		public CreateCustomerMapper()
		{
			CreateMap<CreateCustomerCommandRequest, Domain.Customer.Customer>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => new CustomerId(Guid.NewGuid())));
        }
	}
}

