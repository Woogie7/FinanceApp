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
    internal class CategoryIncomeConfiguration : IEntityTypeConfiguration<CategoryIncome>
    {
        public void Configure(EntityTypeBuilder<CategoryIncome> builder)
        {
            builder.HasKey(x => x.Id);

            var categories = Enum
                    .GetValues<CategoryIncomeEnum>()
                    .Select(r => new CategoryIncome
                    {
                        Id = (int)r,
                        CategoryIncomeName = r.ToString()
                    });

            builder.HasData(categories);
        }
    }
}
