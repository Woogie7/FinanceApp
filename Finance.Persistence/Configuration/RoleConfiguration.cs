using Finance.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Domain.Enum;
using System.Reflection.Emit;

namespace Finance.Persistence.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(u => u.Id);

            builder
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

            builder.HasData(roles);
        }
    }
}
