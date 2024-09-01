using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public string EmailUser { get; set; }

        public UserAlreadyExistsException(string emailUser)
        {
            EmailUser = emailUser;
        }

        public UserAlreadyExistsException(string message, string emailUser) : base(message)
        {
            EmailUser = emailUser;
        }

        public UserAlreadyExistsException(string message, Exception innerException, string emailUser) : base(message, innerException)
        {
            EmailUser = emailUser;
        }
    }
}
