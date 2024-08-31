using Finance.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface.Authentication
{
    public interface IJWTProvider
    {
        string GenerateToken(User user);
    }
}
