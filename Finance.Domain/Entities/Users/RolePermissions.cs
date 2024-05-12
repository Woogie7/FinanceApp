using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities.Users
{
    public class RolePermissions
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
