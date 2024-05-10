using Finance.Domain.Entities.Base.Finance.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities.Users
{
    public class Permission : Entity
    {
        public string Name { get; set; }

        public ICollection<Role> Roles { get; set; } = [];
    }
}
