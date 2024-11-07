using System;
using Application.Customer.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Endpoints
{
	public static class CustomerEndpoint
	{
        public static void MapCustomerEndpoints(this WebApplication app)
        {
            app.MapPost("/customers/create", async (
                [FromBody] CreateCustomerCommandRequest createCustomerCommandRequest,
                IMediator mediator) =>
            {
                // Command'ı mediator aracılığıyla handler'a gönderiyoruz
                CreateCustomerCommandResponse response = await mediator.Send(createCustomerCommandRequest);

                // İşlem sonucuna göre uygun yanıtı döndürüyoruz
                if (response.Success)
                {
                    return Results.Ok(response);
                }
                else
                {
                    return Results.BadRequest(response); // Hata durumunda 400 döndürüyoruz
                }
            })
            .WithName("CreateCustomer")
            .WithSummary("Creates a new customer")
            .WithDescription("Creates a new customer by providing necessary details.")
            .Produces<CreateCustomerCommandResponse>(StatusCodes.Status200OK) // Başarılı durumda 200 döndürülür
            .Produces<CreateCustomerCommandResponse>(StatusCodes.Status400BadRequest); // Hatalı istek durumunda 400 döndürülür
        }
    }
}

