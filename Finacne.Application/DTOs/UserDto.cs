using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.DTOs
{
    public class UserDto
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
