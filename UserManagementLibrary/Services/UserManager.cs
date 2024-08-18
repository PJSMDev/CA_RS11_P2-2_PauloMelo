using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementLibrary.Models;

namespace UserManagementLibrary.Services
{
    public class UserManager
    {
        private List<User> users;
        private int nextId;

        public UserManager()
        {
            users = new List<User>();
            nextId = 1; // Inicia o ID a partir de 1
            SeedData(); // Método para criar dados de teste
        }

        public void AddUser(User user)
        {
            user.Id = nextId++; // Atribui o ID e incrementa para o próximo usuário
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.FullName = user.FullName;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
            }
        }

        public User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.UserName == username);
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> SearchUsersByFullName(string fullName)
        {
            return users.Where(u => u.FullName.IndexOf(fullName, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void ListUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Username: {user.UserName}, Full Name: {user.FullName}, Role: {user.Role}");
            }
        }

        private void SeedData()
        {
            AddUser(new User { FullName = "Jeremias Freitas Resende", UserName = "ADjeremias24", Password = "queroferias", Role = UserRole.Admin });
            AddUser(new User { FullName = "Antónia Amaral Dias", UserName = "PUantonia13", Password = "tbqueroferias", Role = UserRole.PowerUser });
            AddUser(new User { FullName = "Marcelo Rebelo Sousa", UserName = "SUmarcelo02", Password = "feriasopoano", Role = UserRole.SimpleUser });
        }
    }
}
