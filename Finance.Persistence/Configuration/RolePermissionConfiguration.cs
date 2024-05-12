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

namespace Finance.Persistence.Configuration
{
    public partial class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissions>
    {
        private readonly AuthorizationsOptions _authorizationsOptions;
public RolePermissionConfiguration(AuthorizationsOptions authorizationsOptions)
        {
            _authorizationsOptions = authorizationsOptions;
        }

        public void Configure(EntityTypeBuilder<RolePermissions> builder)
        {
            builder.HasKey(r => new {r.RoleId, r.PermissionId});

            builder.HasData(ParseRolePermissions());
        }

        private RolePermissions[] ParseRolePermissions()
        {
            return _authorizationsOptions.RolePermissions
                .SelectMany(rp => rp.Permission
                .Select(p => new RolePermissions
                {
                    RoleId = (int)Enum.Parse<RoleEnum>(rp.Role),
                    PermissionId = (int)Enum.Parse<PermissionsEnum>(p)
                }))
                .ToArray();
        }
    }
}
