using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;


namespace Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationServices(this IServiceCollection collection)
		{
			collection.AddMediatR(typeof(ServiceRegistration));
			collection.AddAutoMapper(typeof(ServiceRegistration));
		}
	}
}

