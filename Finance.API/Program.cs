using Microsoft.Net.Http.Headers;
using Finance.Persistence.Context;
using Finance.Persistence.Repositories;
using Finance.Application.Interface.Repositories;
using Finance.Application;
using Microsoft.EntityFrameworkCore;
using Finance.API.Data;
using Finance.Application.Service;
using Finance.Infrastructure;
using Finance.Infrastructure.Authentication;
using Finance.Infrastructure.Authentication.JWToken;
using Microsoft.AspNetCore.Authorization;
using Finance.API.Midleware;
using Finance.Application.Interface.Authentication;
using Finance.Application.Interface.Cache;

var builder = WebApplication.CreateBuilder(args);
var conf = builder.Configuration;

builder.Services.Configure<JWTOptions>(conf.GetSection(nameof(JWTOptions)));
builder.Services.Configure<AuthorizationsOptions>(conf.GetSection(nameof(AuthorizationsOptions)));

builder.Services.AddApiAuthentication(conf);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DbFinance");
builder.Services.AddDbContext<FinanceDBContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddStackExchangeRedisCache(redisOptions =>
	redisOptions.Configuration = builder.Configuration.GetConnectionString("Cache"));

builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();


builder.Services.AddScoped<IJWTProvider, JWTProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
