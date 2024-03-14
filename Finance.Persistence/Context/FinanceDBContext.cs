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
			
		}

	}
}
