using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string EmailUser { get; set; }

        public UserNotFoundException(string emailUser)
        {
            EmailUser = emailUser;
        }

        public UserNotFoundException(string message, string emailUser) : base(message)
        {
            EmailUser = emailUser;
        }

        public UserNotFoundException(string message, Exception innerException, string emailUser) : base(message, innerException)
        {
            EmailUser = emailUser;
        }
    }
}
