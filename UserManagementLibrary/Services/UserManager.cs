using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementLibrary.Models;

namespace UserManagementLibrary.Services
{
    public class UserManager
    {
        private List<User> users;

        public UserManager()
        {
            users = new List<User>();
            SeedData(); // Método para criar dados de teste
        }

        // Adiciona um novo usuário à lista
        public void AddUser(User user)
        {
            users.Add(user);
        }

        // Atualiza um usuário existente
        public void UpdateUser(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser != null)
            {
                existingUser.FullName = user.FullName;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
            }
        }

        // Busca um usuário pelo username
        public User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.UserName == username);
        }

        // Busca um usuário pelo ID
        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        // Busca usuários pelo nome completo
        public IEnumerable<User> SearchUsersByFullName(string fullName)
        {
            return users.Where(u => u.FullName.Contains(fullName, StringComparison.OrdinalIgnoreCase));
        }

        // Lista todos os usuários
        public void ListUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Username: {user.UserName}, Full Name: {user.FullName}, Role: {user.Role}");
            }
        }

        // Método para criar dados de teste
        private void SeedData()
        {
            users.Add(new User { Id = 1, FullName = "Jeremias Freitas Resende", UserName = "ADjeremias24", Password = "queroferias", Role = UserRole.Admin });
            users.Add(new User { Id = 2, FullName = "Antónia Amaral Dias", UserName = "PUantonia13", Password = "tbqueroferias", Role = UserRole.PowerUser });
            users.Add(new User { Id = 3, FullName = "Marcelo Rebelo Sousa", UserName = "SUmarcelo02", Password = "feriasopoano", Role = UserRole.SimpleUser });
        }
    }
}
