using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementLibrary.Models;

namespace UserManagementLibrary.Services
{
    public class UserManager
    {
        private readonly List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                FullName = "Jeremias Freitas Resende",
                UserName = "ADjeremias24",
                Password = "queroferias",
                Role = UserRole.Admin
            },
            new User
            {
                Id = 2,
                FullName = "Antónia Amaral Dias",
                UserName = "PUantonia13",
                Password = "tbqueroferias",
                Role = UserRole.PowerUser
            },
            new User
            {
                Id = 3,
                FullName = "Marcelo Rebelo Sousa",
                UserName = "SUmarcelo02",
                Password = "feriasopoano",
                Role = UserRole.SimpleUser
            }
        };

        public User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> SearchUsersByFullName(string fullName)
        {
            return users.Where(u => u.FullName.IndexOf(fullName, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }
    }
}
