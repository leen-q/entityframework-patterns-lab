using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Admin : User
    {
        public Admin(int userId, string userLogin, string userPassword) : base(userId, userLogin, userPassword, nameof(Admin))
        {
        }
    }
}
