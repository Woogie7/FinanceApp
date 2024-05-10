using Microsoft.Net.Http.Headers;
using Finance.Persistence.Context;
using Finance.Persistence.Repositories;
using Finance.Application.Interface.Repositories;
using Finance.Application;
using Microsoft.EntityFrameworkCore;
using Finance.API.Data;
using Finance.Application.Service;
using Finance.Application.Interface;
using Finance.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var conf = builder.Configuration;

builder.Services.Configure<JWTOptions>(conf.GetSection(nameof(JWTOptions)));
builder.Services.AddApiAuthentication(conf);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Icnome");
builder.Services.AddDbContext<FinanceDBContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

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

app.UseExceptionHandlers();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
