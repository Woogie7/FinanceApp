using Microsoft.Net.Http.Headers;
using Finance.Persistence.Context;
using Finance.Persistence.Repositories;
using Finance.Application.Interface.Repositories;
using Finance.Application;
using Microsoft.EntityFrameworkCore;
using Finance.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Icnome");
builder.Services.AddDbContext<FinanceDBContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AppApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.MigrateDbAsync();
}

app.UseCors(p=>
	p.WithOrigins("https://localhost:7274", "https://localhost:7274")
	.AllowAnyMethod()
	.WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

//app.UseExceptionHandlers();

app.UseAuthorization();

app.MapControllers();



app.Run();
