using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.Security.Identity;

namespace CCL.Security
{
    public static class SecurityContext
    {
        static User _user = null;
​
        public static User GetUser()
        {
            return _user;
        }
​
        public static void SetUser(User user)
        {
            _user = user;
        }
    }
}

