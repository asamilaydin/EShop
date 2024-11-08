using Domain;
using Application;
using Persistence;
using EShopApp.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var customerEndpoint = new CustomerEndpoint();
customerEndpoint.MapEndpoint(app);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
