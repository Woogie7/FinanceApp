using Finance.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Configuration
{
    internal class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.Category)
                   .WithMany(u => u.Incomes)
                   .HasForeignKey(u => u.CategoryIncomeId)
                   .IsRequired();

            builder.HasOne(u => u.Currency)
                   .WithMany(u => u.Incomes)
                   .HasForeignKey(u => u.CurrencyId)
                   .IsRequired();

        }
    }
}
