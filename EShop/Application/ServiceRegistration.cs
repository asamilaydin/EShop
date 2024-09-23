using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Customer.Create;

namespace Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationServices(this IServiceCollection collection)
		{
			collection.AddMediatR(typeof(ServiceRegistration));
			collection.AddAutoMapper(typeof(ServiceRegistration));
            collection.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>());
        }
	}
}

