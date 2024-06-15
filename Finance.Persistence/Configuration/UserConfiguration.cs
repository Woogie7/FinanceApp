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
using System.Reflection.Emit;

namespace Finance.Persistence.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Role)
                   .WithMany(u => u.Users)
                   .HasForeignKey(u => u.RoleId)
                   .IsRequired();
        }
    }
}
