using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementLibrary.Models;

namespace UserManagementLibrary.Services
{
    public class UserManager
    {
        private List<User> _users;
        private int _nextId;

        public UserManager()
        {
            _users = new List<User>();
            _nextId = 1;

            // Criar utilizadores iniciais
            _users.Add(new User(_nextId++, "admin", "adminpass", UserProfile.Admin));
            _users.Add(new User(_nextId++, "poweruser", "powerpass", UserProfile.PowerUser));
            _users.Add(new User(_nextId++, "simpleuser", "simplepass", UserProfile.SimpleUser));
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public bool RemoveUser(int id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                return true;
            }
            return false;
        }

        public User GetUserById(int id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _users.SingleOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<User> ListUsers()
        {
            return _users;
        }
    }
}
