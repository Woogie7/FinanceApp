using Finance.Application.DTOs;
using Finance.Application.Interface;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using Finance.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Service
{
    public class UserService
    {
        private readonly IPasswordHasher _hasher;
        private readonly IUserRepository _userRepository;
        private readonly IJWTProvider _JWTProvider; 

        public UserService(IPasswordHasher hasher, IUserRepository userRepository, IJWTProvider jWTProvider)
        {
            _hasher = hasher;
            _userRepository = userRepository;
            _JWTProvider = jWTProvider;
        }

        public async Task Register(CreateUserDto newUser)
        {
            var hashedPassword = _hasher.GeneratePassword(newUser.PasswordHash);

            var user = new CreateUserDto
            { 
                UserName = newUser.UserName,
                Email = newUser.Email,
                PasswordHash = hashedPassword
            };

            await _userRepository.Add(user);
        }

        public async Task<string> Login(UserDto userResponse)
        {
            var user = await _userRepository.GetUserByEmail(userResponse.Email);

            var result = _hasher.IsVerify(userResponse.PasswordHash, user.PasswordHash);

            if (!result)
            {
                throw new Exception("Faild to login");
            }

            var token = _JWTProvider.GenerateToken(user);

            return token;

        }
    }
}
