using Finance.API.Midleware;
using Finance.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Finance.API.Data
{
	public static class DataExtensions
	{
		public static async Task MigrateDbAsync(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var DbContext = scope.ServiceProvider.GetRequiredService<FinanceDBContext>();
			await DbContext.Database.MigrateAsync();
		}

		public static IApplicationBuilder UseExceptionHandlers(this IApplicationBuilder app)
		{
			return app.UseMiddleware<ClobalExceptionHandlerMidleware>();
		}
	}
}
