using ConsoleApp1.Data.Contexts;
using ConsoleApp1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Utils
{
    public static class AddUserExtension
    {
         
        public static bool AddUserCheck(this User user,string name, string username)
        {
            AppDbContext _appDbContext = new AppDbContext();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || (name.Length < 3) || (username.Length < 3))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static User GetBYIdExt(this User user,int id)
        {
            AppDbContext _appDbContext = new AppDbContext();
            foreach (User user1 in _appDbContext.Users)
            {
                if (user1.Id == id)
                {
                    Console.WriteLine("User Founded");
                    return user1;
                }
            }
            throw new NullReferenceException();
        }
    }
}
