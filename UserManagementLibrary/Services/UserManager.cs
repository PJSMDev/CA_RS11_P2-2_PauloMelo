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
            users.Add(new User { FullName = "Administrator", UserName = "admin", Password = "admin", Role = UserRole.Admin });
            users.Add(new User { FullName = "Power User", UserName = "poweruser", Password = "poweruser", Role = UserRole.PowerUser });
            users.Add(new User { FullName = "Simple User", UserName = "simpleuser", Password = "simpleuser", Role = UserRole.SimpleUser });
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
