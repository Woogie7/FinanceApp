using Finance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finance.Persistence.Context
{
	public class FinanceDBContext(DbContextOptions<FinanceDBContext> dbContextOptions) : DbContext(dbContextOptions)
	{
		public DbSet<Income> Incomes { get; set; }
		public DbSet<CategoryIncome> CategoryIncomes { get; set;}

		public DbSet<Currency> Currencies { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Currency>().HasData(
            new Currency
            {
                Id = 1,  // Предполагаем, что Entity имеет идентификатор
                CurrencyName = "USD",  // Валюта в долларах США
                Incomes = new List<Income>()  // Инициализация пустого списка
            },
            new Currency
            {
                Id = 2,
                CurrencyName = "EUR",  // Валюта в евро
                Incomes = new List<Income>()
            },
            new Currency
            {
                Id = 3,
                CurrencyName = "RUB",  // Валюта в японских иенах
                Incomes = new List<Income>()
            }
            );

            modelBuilder.Entity<CategoryIncome>().HasData(
            new CategoryIncome
            {
                Id = 1,  // Предполагаем, что Entity имеет идентификатор
                CategoryIncomeName = "Зарплата",  // Валюта в долларах США
                Incomes = new List<Income>()  // Инициализация пустого списка
            },
            new CategoryIncome
            {
                Id = 2,
                CategoryIncomeName = "Подарок",  // Валюта в евро
                Incomes = new List<Income>()
            });
           
        }

	}
}
