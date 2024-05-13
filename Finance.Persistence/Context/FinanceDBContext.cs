using Finance.Domain.Entities;
using Finance.Domain.Entities.Users;
using Finance.Domain.Enum;
using Finance.Infrastructure.Authentication;
using Finance.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Finance.Persistence.Context
{
    public class FinanceDBContext(
        DbContextOptions<FinanceDBContext> dbContextOptions,
        IOptions<AuthorizationsOptions> authOptions) : DbContext(dbContextOptions)
	{
		public DbSet<Income> Incomes { get; set; }
		public DbSet<CategoryIncome> CategoryIncomes { get; set;}
		public DbSet<Currency> Currencies { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


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

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                        .HasOne(u => u.Role)
                        .WithMany(u => u.Users)
                        .HasForeignKey(u => u.RoleId)
                        .IsRequired();

            modelBuilder.Entity<Role>().HasKey(u => u.Id);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithMany(r => r.Roles)
                .UsingEntity<RolePermissions>(
                    p => p.HasOne<Permission>().WithMany().HasForeignKey(p => p.PermissionId),
                    r => r.HasOne<Role>().WithMany().HasForeignKey(r => r.RoleId));

            var roles = Enum
                .GetValues<RoleEnum>()
                .Select(r => new Role
                {
                    Id = (int)r,
                    Name = r.ToString()
                });

            modelBuilder.Entity<Role>().HasData(roles);

            modelBuilder.Entity<Permission>().HasKey(u => u.Id);

            var permissions = Enum
                .GetValues<PermissionsEnum>()
                .Select(r => new Permission
                {
                    Id = (int)r,
                    Name = r.ToString()
                });

            modelBuilder.Entity<Permission>().HasData(permissions);

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
        }

	}
}
