using Finance.Domain.Entities;
using Finance.Domain.Entities.Users;
using Finance.Domain.Enum;
using Finance.Infrastructure.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Configuration;

internal class CategoryExpenseConfiguration : IEntityTypeConfiguration<CategoryExpense>
{
    public void Configure(EntityTypeBuilder<CategoryExpense> builder)
    {
        builder.HasKey(x => x.Id);

        var roles = Enum
                .GetValues<CategoryExpenseEnum>()
                .Select(r => new CategoryExpense
                {
                    Id = (int)r,
                    CategoryExpenseName = r.ToString()
                });

        builder.HasData(roles);
    }
}