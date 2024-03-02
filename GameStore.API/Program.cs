using GameStore.API.Data;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectString = builder.Configuration.GetConnectionString("Icnome");
builder.Services.AddNpgsql<FinanceDBContext>(connectString);

var app = builder.Build();

app.UseCors(p=>
	p.WithOrigins("https://localhost:7274", "https://localhost:7274")
	.AllowAnyMethod()
	.WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.MigrateDbAsync();

app.Run();
