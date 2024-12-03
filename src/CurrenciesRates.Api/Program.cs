using CurrenciesRates.Application.Exception;
using CurrenciesRates.Application.Handlers;
using CurrenciesRates.Application.Queries;
using CurrenciesRates.Application.Repositories;
using CurrenciesRates.Application.Services;
using CurrenciesRates.Application.Stores;
using CurrenciesRates.Infrastructure.EF;
using CurrenciesRates.Infrastructure.Repositories;
using CurrenciesRates.Infrastructure.Store;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCurrencyRateByDateHandler).Assembly));

builder.Services.AddDbContext<CurrenciesRatesContext>
(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddScoped<ICurrenciesService, CurrenciesService>();
builder.Services.AddScoped<ICurrencyRateStore, NBPStore>();
builder.Services.AddScoped<ICurrenciesRatesRepository, CurrenciesRatesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/currency-rate", async (IMediator mediator, string currencyCode, DateTime date) =>
    {
        try
        {
            var result = await mediator.Send(new GetCurrencyRateByDate(currencyCode, date));
            return Results.Ok(result);
        }
        catch (BadRequestException e)
        {
            return Results.BadRequest(e.Message);
        }
       
    })
    .WithName("currency-rate")
    .WithOpenApi();

app.MapGet("", () => "Hello World!")
    .WithName("HelloWorld")
    .WithOpenApi();

app.Run();