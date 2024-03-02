using GameStore.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectString = builder.Configuration.GetConnectionString("Icnome");
builder.Services.AddNpgsql<FinanceDBContext>(connectString);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.MigrateDbAsync();

app.Run();
