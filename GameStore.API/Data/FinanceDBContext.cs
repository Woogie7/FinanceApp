using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data
{
	public class FinanceDBContext(DbContextOptions<FinanceDBContext> dbContextOptions) : DbContext(dbContextOptions)
	{
		public DbSet<Income> Incomes { get; set; }
		public DbSet<CategoryIncome> CategoryIncomes { get; set;}

		public DbSet<Currency> Currencies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Currency>().HasData(
				new { Id = 1, CurrencyName = "USD" },
				new { Id = 2, CurrencyName = "EUR" },
				new { Id = 3, CurrencyName = "RUB" }
				);
			modelBuilder.Entity<CategoryIncome>().HasData(
				new { Id = 1, CategoryIncomeName = "Заработок" },
				new { Id = 2, CategoryIncomeName = "Инвестиции" },
				new { Id = 3, CategoryIncomeName = "Подарок" });
		}

	}
}
