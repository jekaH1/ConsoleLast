using ConsoleApp1.Data.Contexts;
using ConsoleApp1.Data.Interfaces;
using ConsoleApp1.Data.Model;
using ConsoleApp1.Data.Static;
using ConsoleApp1.Data.Utils;
using System.Transactions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user2 = new User("Murad", "Aliyev", "+999999999", UserStatus.Admin);

            string choice;  
            do
            {
                Console.WriteLine("Enter Your choice\n" +
                    "1-For Adding\n" +
                    "2-Edit user by id\n" +
                    "3-Get All\n" +
                    "4-Get By id\n" +
                    "5-Remove BY id\n" +
                    "6-Remove All\n" +
                    "7-For exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("enter name");
                            string name = Console.ReadLine();
                            Console.WriteLine("enter Surname");
                            string surname = Console.ReadLine();
                            Console.WriteLine("enter phone");
                            string phone = Console.ReadLine();
                            Console.WriteLine("enter status");
                            UserStatus status = (UserStatus)int.Parse(Console.ReadLine());

                            using (AppDbContext _appDbContext = new AppDbContext())
                            {
                                User user = new User(name, surname, phone, status);
                                if (user.AddUserCheck(user.Name, user.Surname))
                                {
                                    List<User> users = new List<User>();
                                    users.Add(user);
                                    _appDbContext.Users.AddRange(users);
                                    _appDbContext.SaveChanges();
                                    Console.WriteLine("added!");

                                }
                            };
                        } while (!true);
                            
                        break;
                    case "2":
                        do
                        {
                            Console.WriteLine("enter the id");
                            int editId = Convert.ToInt32(Console.ReadLine());
                            user2.EditUserById(editId);
                        } while (!true);
                        break;

                    case "3":
                        do
                        {
                            foreach (var item in user2.GetAll())
                            {
                                Console.WriteLine(item);
                            }
                            
                        } while (!true);
                        break;

                    case "4":
                        do
                        {
                            Console.WriteLine("enter the id");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(user2.GetById(searchId));
                        } while (!true);
                        break;
                    case "5":
                        do
                        {
                            Console.WriteLine("enter the id");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            user2.RemoveById(searchId);
                            Console.WriteLine("removed");
                        } while (!true);
                        break;
                    case "6":
                        do
                        {
                           user2.RemoveAll();
                        } while (!true);
                        break;
                    default:
                        break;
                }
            } while (choice!="7");
        }
    }
}