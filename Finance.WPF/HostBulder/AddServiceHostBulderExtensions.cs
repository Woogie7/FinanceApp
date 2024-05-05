using Finance.Wpf.Service;
using Finance.Wpf.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Finance.HostBulder
{
    public static class AddServiceHostBulderExtensions
	{
		public static IHostBuilder AddService(this IHostBuilder host)
		{
			host.ConfigureServices(service =>
			{
				service.AddSingleton<IIncomeService, IncomeService>();
				service.AddSingleton<ICurrencyService, CurrencyService>();
				service.AddSingleton<ICategoryIncomeService, CategoryIncomeService>();
				//service.AddSingleton<IAuthenticationService, AuthenticationService>();
			});

			return host;
		}
	}
}
