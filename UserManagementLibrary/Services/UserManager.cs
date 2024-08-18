using System.Collections.Generic;
using System.Linq;
using UserManagementLibrary.Models;

namespace UserManagementLibrary.Services
{
    public class UserManager
    {
        private readonly List<User> users = new List<User>();

        public UserManager()
        {
            // Criação dos usuários iniciais
            users.Add(new User { FullName = "Jeremias Freitas Resende", UserName = "ADjeremias24", Password = "queroferias", Role = UserRole.Admin });
            users.Add(new User { FullName = "Antónia Amaral Dias", UserName = "PUantonia13", Password = "tbqueroferias", Role = UserRole.PowerUser });
            users.Add(new User { FullName = "Marcelo Rebelo Sousa", UserName = "SUmarcelo02", Password = "feriasopoano", Role = UserRole.SimpleUser });
        }

        public void CreateUser(string fullName, string userName, string password, UserRole role)
        {
            users.Add(new User { FullName = fullName, UserName = userName, Password = password, Role = role });
        }

        public User GetUser(string userName)
        {
            return users.FirstOrDefault(u => u.UserName == userName);
        }

        public void ListUsers()
        {
            foreach (var user in users)
            {
                System.Console.WriteLine($"Full Name: {user.FullName}, UserName: {user.UserName}, Role: {user.Role}");
            }
        }
    }
}
