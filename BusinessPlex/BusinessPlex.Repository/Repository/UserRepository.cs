using BusinessPlex.DatabaseContext.DatabaseContext;
using BusinessPlex.Models.Models;
using BusinessPlex.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Repository.Repository
{
    public class UserRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();
        public int Login(User user)
        {
            var users = db.Users.FirstOrDefault(c => c.UserName == user.UserName);
            if (users != null)
            {
                if (string.Compare(Crypto.Hash(user.Password), users.Password) == 0 && users.IsEmailVerified == true)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
