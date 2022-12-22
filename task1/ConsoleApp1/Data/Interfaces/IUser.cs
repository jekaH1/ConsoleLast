using ConsoleApp1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Interfaces
{
    public interface IUser
    {
        public void AddUser(User user);
        public User GetById(int id);
        public List<User> GetAll();
        public void EditUserById(int id);
        public void RemoveById(int id);
        public void RemoveAll();



    }
}
