using Finance.Domain.Entities.Base;
using Finance.Domain.Entities.Base.Finance.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities.Users
{
    public class Role : Entity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Permission> Permissions { get; set; } = [];

        public ICollection<User> Users { get; set; } = [];
    }
}
