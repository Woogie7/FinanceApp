using Microsoft.Net.Http.Headers;
using Finance.Persistence.Context;
using Finance.Domain.Entities;
using Finance.Persistence.Repositories;
using Finance.Application.Interface.Repositories;
using Finance.Application;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Finance.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectString = builder.Configuration.GetConnectionString("Icnome");
builder.Services.AddNpgsql<FinanceDBContext>(connectString);

builder.Services.AddScoped<IGenericRepository<Income>, GenericRepository<Income>>();

builder.Services.AddMediatR(typeof(ApplicationMediatREntryPoint).Assembly);

var app = builder.Build();

app.UseCors(p=>
	p.WithOrigins("https://localhost:7274", "https://localhost:7274")
	.AllowAnyMethod()
	.WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseExceptionHandlers();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<>;


app.Run();
