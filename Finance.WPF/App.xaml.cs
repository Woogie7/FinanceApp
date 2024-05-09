using Microsoft.Extensions.Hosting;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Finance.ViewModel;
using Finance.View;
using Finance.Service.Store;
using System;
using Microsoft.Extensions.Configuration;
using Finance.HostBulder;
using System.Net.Http;

namespace Finance
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
		private readonly IHost _host;

		public App()
		{
			_host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(c =>
				{
					c.AddJsonFile("appsettings.json");
				})
				.ConfigureServices((context, service) =>
				{
					service.AddSingleton<NavigationStore>();
                    //service.AddSingleton<IDataService<User>, UserDataServiсe>();

                    service.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });

                    service.AddSingleton<MainWindowViewModel>();

					service.AddTransient<IncomeViewModel>();
					service.AddSingleton<Func<IncomeViewModel>>(s => () => s.GetRequiredService<IncomeViewModel>());
					service.AddSingleton<NavigationService<IncomeViewModel>>();

					service.AddTransient<ExpanseViewModel>();
					service.AddSingleton<Func<ExpanseViewModel>>(s => () => s.GetRequiredService<ExpanseViewModel>());
					service.AddSingleton<NavigationService<ExpanseViewModel>>();

					service.AddTransient<BalanceViewModel>();
					service.AddSingleton<Func<BalanceViewModel>>(s => () => s.GetRequiredService<BalanceViewModel>());
					service.AddSingleton<NavigationService<BalanceViewModel>>();

					service.AddSingleton<NavigationService<IncomeViewModel>>();
					service.AddSingleton<NavigationService<ExpanseViewModel>>();
					service.AddSingleton<NavigationService<BalanceViewModel>>();


					service.AddSingleton<MainWindow>(s => new MainWindow()
					{
						DataContext = s.GetRequiredService<MainWindowViewModel>()
					});
				}).AddService()
				.Build();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			_host.Start();

			//IAuthenticationService authentication = _host.Services.GetRequiredService<IAuthenticationService>();
			//authentication.Register("test@gmail.com", "Woogie", "123","123");


			NavigationService<IncomeViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<IncomeViewModel>>();
			navigationService.Navigate();

			MainWindow = _host.Services.GetRequiredService<MainWindow>();
			MainWindow.Show();

			base.OnStartup(e);
		}

		protected override void OnExit(ExitEventArgs e)
		{
			_host.Dispose();

			base.OnExit(e);
		}
	}
}
