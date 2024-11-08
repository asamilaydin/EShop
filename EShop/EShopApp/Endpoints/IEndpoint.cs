using System;
using Microsoft.AspNetCore.Routing;

namespace EShopApp.Endpoints
{
	public interface IEndpoint
	{
		void MapEndpoint(IEndpointRouteBuilder app);
	}
}

