using Finance.Application.Interface;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
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

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _hasher.GeneratePassword(password);

            var user = new User(Guid.NewGuid(),userName, email, hashedPassword);

            await _userRepository.Add(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);

            var result = _hasher.IsVerify(password, user.PasswordHash);

            if (!result)
            {
                throw new Exception("Faild to login");
            }

            var token = _JWTProvider.GenerateToken(user);

            return token;

        }
    }
}
