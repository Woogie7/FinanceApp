using Finance.API.Midleware;
using Finance.Infrastructure;
using Finance.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

		public static void AddApiAuthentication(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			var jwtOptions = configuration.GetSection(nameof(JWTOptions)).Get<JWTOptions>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
				{
					options.TokenValidationParameters = new()
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(
							Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
					};

					options.Events = new JwtBearerEvents()
					{
						OnMessageReceived = context =>
						{
							context.Token = context.Request.Cookies["tasty-cookes"];
							return Task.CompletedTask;
						}
					};
				});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("AdminPolicy", policy =>
				{
					policy.Requirements.Add();
				});
			});
		}
	}
}
