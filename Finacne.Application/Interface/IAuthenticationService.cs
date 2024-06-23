using Finance.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface
{
    public interface IAuthenticationService
    {
        Task Register(CreateUserDto userDto);
        Task<UserDto> Login(UserDto userDto);
    }
}
