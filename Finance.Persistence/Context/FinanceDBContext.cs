using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using Finance.Domain.Entities.Users;
using Finance.Domain.Enum;
using Finance.Infrastructure.Authentication;
using Finance.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data;

namespace Finance.Persistence.Context
{
    public class FinanceDBContext(
        DbContextOptions<FinanceDBContext> dbContextOptions,
        IOptions<AuthorizationsOptions> authOptions) : DbContext(dbContextOptions), IUnitOfWork
	{
		public DbSet<Income> Incomes { get; set; }
		public DbSet<CategoryIncome> CategoryIncomes { get; set;}
		public DbSet<Currency> Currencies { get; set; }
		public DbSet<Expense> Expenses { get; set; }
		public DbSet<CategoryExpense> CategoryExpenses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
            modelBuilder.ApplyConfiguration(new CategoryExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryIncomeConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new IncomeConfiguration());
        }

        Task IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return this.SaveChangesAsync(cancellationToken);
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = this.Database.BeginTransaction();

            return transaction.GetDbTransaction();
        }
    }
}
