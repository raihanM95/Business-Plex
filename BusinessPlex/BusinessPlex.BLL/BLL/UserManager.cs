using BusinessPlex.Models.Models;
using BusinessPlex.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.BLL.BLL
{
    public class UserManager
    {
        UserRepository _userRepository = new UserRepository();

        public int Login(User user)
        {
            return _userRepository.Login(user);
        }
    }
}
