using main.Models.Departments;
using main.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.Interface
{
    internal interface IUsersRepository
    {
        public IEnumerable<Users> UsersModel();
    }
}
