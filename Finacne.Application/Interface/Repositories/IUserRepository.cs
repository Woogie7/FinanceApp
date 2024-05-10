using Finance.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetUserByEmail(string email);
    }
}
