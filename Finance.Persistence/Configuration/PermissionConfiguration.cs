using Finance.Domain.Entities.Users;
using Finance.Domain.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Finance.Persistence.Configuration
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(u => u.Id);

            var permissions = Enum
                .GetValues<PermissionsEnum>()
                .Select(r => new Permission
                {
                    Id = (int)r,
                    Name = r.ToString()
                });

            builder.HasData(permissions);
        }
    }
}
