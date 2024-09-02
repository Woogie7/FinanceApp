using Finance.Application.DTOs.UserDto;
using Finance.Application.Interface.Authentication;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using Finance.Domain.Entities.Users;
using Finance.Domain.Exceptions;
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
            var existingUser = await _userRepository.GetUserByEmail(newUser.Email);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException(newUser.Email);
            }

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

            if (user == null)
            {
                throw new UserNotFoundException(userResponse.Email);
            }

            var result = _hasher.IsVerify(userResponse.PasswordHash, user.PasswordHash);

            if (!result)
            {
                throw new InvalidPasswordException(user.Email, user.PasswordHash);
            }

            var token = _JWTProvider.GenerateToken(user);

            return token;

        }
    }
}
