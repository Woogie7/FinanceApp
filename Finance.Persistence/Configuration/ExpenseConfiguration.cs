using Finance.Domain.Entities;
using Finance.Domain.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Configuration
{
    internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.Category)
                   .WithMany(u => u.Expenses)
                   .HasForeignKey(u => u.CategoryExpenseId)
                   .IsRequired();

            builder.HasOne(u => u.Currency)
                   .WithMany(u => u.Expenses)
                   .HasForeignKey(u => u.CurrencyId)
                   .IsRequired();
        }
    }
}
