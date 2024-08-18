using System;
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
            // Inicializa com os usuários fornecidos por você
            InitializeTestUsers();
        }

        private void InitializeTestUsers()
        {
            // Adiciona os usuários específicos fornecidos
            users.Add(new User
            {
                Id = 1,
                FullName = "Jeremias Freitas Resende",
                UserName = "ADjeremias24",
                Password = "queroferias",
                Role = UserRole.Admin
            });

            users.Add(new User
            {
                Id = 2,
                FullName = "Antónia Amaral Dias",
                UserName = "PUantonia13",
                Password = "tbqueroferias",
                Role = UserRole.PowerUser
            });

            users.Add(new User
            {
                Id = 3,
                FullName = "Marcelo Rebelo Sousa",
                UserName = "SUmarcelo02",
                Password = "feriasopoano",
                Role = UserRole.SimpleUser
            });
        }

        // Método para adicionar usuários para fins de teste
        public void AddUser(User user)
        {
            users.Add(user);
        }

        // Método para obter um usuário pelo nome de usuário
        public User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        // Método para obter todos os usuários
        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        // Método para buscar usuários por nome completo
        public IEnumerable<User> SearchUsersByFullName(string fullName)
        {
            return users.Where(u => u.FullName.IndexOf(fullName, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        // Método para buscar usuários por ID
        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        // Método para atualizar dados do usuário
        public bool UpdateUser(User updatedUser)
        {
            var user = GetUserById(updatedUser.Id);
            if (user == null) return false;

            user.FullName = updatedUser.FullName;
            user.Password = updatedUser.Password;
            user.Role = updatedUser.Role;

            return true;
        }
    }
}
