using System.Collections.Generic;
using System.Linq;

namespace UserAdministration.Services
{
    /// <summary>
    /// Service class for user operations.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly List<User> users;

        public UserService()
        {
            users = new List<User>();
        }

        #region Public Methods

        public void CreateDefaultUsers()
        {
            // Create default users
            users.Add(new User("Admin User", "admin", "admin123", UserRole.Admin));
            users.Add(new User("Power User", "poweruser", "power123", UserRole.PowerUser));
            users.Add(new User("Simple User", "simpleuser", "simple123", UserRole.SimpleUser));
        }

        public User AuthenticateUser()
        {
            ConsoleUtility.WriteMessage("Username: ");
            string username = Console.ReadLine();

            ConsoleUtility.WriteMessage("Password: ");
            string password = ConsoleUtility.ReadPassword();

            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(string username, string newPassword, UserRole newRole)
        {
            var user = GetUserByUsername(username);
            if (user != null)
            {
                user.Password = newPassword;
                user.Role = newRole;
            }
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        public List<User> GetUsersByRole(UserRole role)
        {
            return users.Where(u => u.Role == role).ToList();
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        #endregion
    }
}
