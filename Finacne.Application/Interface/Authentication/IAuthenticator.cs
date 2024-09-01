﻿using Finance.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface.Authentication
{
    public interface IAuthenticator
    {
        UserDto CurrentUser { get; }
        bool IsLoggedIn { get; }
        Task Register(CreateUserDto userDto);
        Task<UserDto> Login(UserDto userDto);
        void Logout();

    }
}