using Microsoft.Net.Http.Headers;
using Finance.Persistence.Context;
using Finacne.Application.Repositories;
using Finance.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Finance.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectString = builder.Configuration.GetConnectionString("Icnome");
builder.Services.AddNpgsql<FinanceDBContext>(connectString);
builder.Services.AddScoped<IGenericRepository<Income>, GenericRepository<Income>>();

var app = builder.Build();

app.UseCors(p=>
	p.WithOrigins("https://localhost:7274", "https://localhost:7274")
	.AllowAnyMethod()
	.WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//await app.MigrateDbAsync();

app.Run();
