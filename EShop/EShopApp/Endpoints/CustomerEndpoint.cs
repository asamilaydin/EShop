using System;
using Application.Customer.Create;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace EShopApp.Endpoints
{
    public class CustomerEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var routeGroup = app
                .MapGroup(prefix: "customers")
                .WithTags("customers");

            MapV1(routeGroup);
        }

        private static void MapV1(IEndpointRouteBuilder routeGroup)
        {
            routeGroup
                .MapPost("create", async (
                    CreateCustomerCommandRequest request,
                    ISender sender,
     
                    CancellationToken cancellationToken) =>
                {
                    var result = await sender.Send(request, cancellationToken);

                    if (result.Success == true)
                    {
                        return Results.Ok(result);
                    }
                    else
                    {
                        return Results.BadRequest(result);
                    }
                })
                //.MapToVersion  neden olmadı
                .AllowAnonymous()
                .WithSummary("müşteri kayıt")
                .Produces<CreateCustomerCommandResponse>(StatusCodes.Status200OK)
                .Produces<CreateCustomerCommandResponse>(StatusCodes.Status400BadRequest);
        }

    }
}

