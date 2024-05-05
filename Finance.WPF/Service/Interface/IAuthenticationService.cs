using Finance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Wpf.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<bool> Register(string email, string name, string password, string confirmPassword);

        //Task<User> Login(string userName, string password);
    }
}
