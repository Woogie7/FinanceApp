using Finance.Application.DTOs.UserDto;
using Finance.Domain.Entities.Users;
using Finance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface.Repositories
{
    public interface IUserRepository
    {
        Task Add(CreateUserDto user);
        Task<User> GetUserByEmail(string email);

        Task<HashSet<string>> GetUserPermissionsAsync(Guid userId);
    }
}
