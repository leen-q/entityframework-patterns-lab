using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string userLogin, string userPassword, string userType)
        {
            UserId = userId;
            UserLogin = userLogin;
            UserPassword = userPassword;
            UserType = userType;
        }
        public int UserId { get; }
        public string UserLogin { get; }
        public string UserPassword { get; }
        protected string UserType { get; }
    }
}
