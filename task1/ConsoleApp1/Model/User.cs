using ConsoleApp1.Data.Base;
using ConsoleApp1.Data.Contexts;
using ConsoleApp1.Data.Interfaces;
using ConsoleApp1.Data.Static;
using ConsoleApp1.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Model
{
    public class User : BaseEntity ,IUser
    {
        public User(string name,string surname,string phone, UserStatus status)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Status = status;
        }
         
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public UserStatus Status { get; set; }

        public void AddUser(User user)
        {
            using (AppDbContext _appDbContext = new AppDbContext())
            {
                if (user.AddUserCheck(user.Name,user.Surname))
                {
                _appDbContext.Users.Add(user);
                _appDbContext.SaveChanges();
                    
                }
            };
        }

        public void EditUserById(int id)
        {
            using (AppDbContext _appDbContext = new AppDbContext())
            {
                foreach (var user in _appDbContext.Users.ToList())
                {
                    if (user.Id == id)
                    {
                        _appDbContext.Update(user);
                        Console.WriteLine("Edit Name");
                        user.Name = Console.ReadLine();
                        Console.WriteLine("Edit Surname");
                        user.Surname = Console.ReadLine();
                        Console.WriteLine("Edit Phone");
                        user.Phone= Console.ReadLine();
                        Console.WriteLine("Edit Status 1-3");
                        user.Status = (UserStatus)int.Parse(Console.ReadLine());
                        _appDbContext.SaveChanges();
                    }
                }
            }
        }
        public List<User> GetAll()
        {
            using (AppDbContext _appDbContext = new AppDbContext())
            {
                return _appDbContext.Users.ToList();
            }
        }

        public User GetById(int id)
        {
            using (AppDbContext _appDbContext = new AppDbContext())
            {
                foreach (var tch in _appDbContext.Users)
                {
                    if (tch.Id == id)
                    return tch;
                }
                return null;
            }
        }

        public void RemoveAll()
        {
            using (AppDbContext _appDbContext = new AppDbContext())
            {
                _appDbContext.Users.RemoveRange(_appDbContext.Users.ToList());
                _appDbContext.SaveChanges();
                Console.WriteLine("All removed");
            }
        }
        public void RemoveById(int id)
        {
            using (AppDbContext _appDbContext = new AppDbContext())
            {
                foreach (var tch in _appDbContext.Users.ToList())
                {
                    if (tch.Id == id)
                    _appDbContext.Users.Remove(tch);
                    _appDbContext.SaveChanges();
                    
                }
            }
            AppDbContext _appDbContext2 = new AppDbContext();
            User user= _appDbContext2.Users.FirstOrDefault(x => x.Id == id);

            if (user == null) throw new NullReferenceException();
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Surname} {Phone} {Status}";
        }
    }
}
