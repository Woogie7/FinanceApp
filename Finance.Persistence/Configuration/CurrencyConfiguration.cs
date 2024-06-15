using Finance.Domain.Entities;
using Finance.Domain.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Domain.Entities.Users;

namespace Finance.Persistence.Configuration
{
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(u => u.Id);

            var currency = Enum
                .GetValues<CurrencyEnum>()
                .Select(r => new Currency
                {
                    Id = (int)r,
                    CurrencyName = r.ToString()
                });

            builder.HasData(currency);
        }
    }
}
