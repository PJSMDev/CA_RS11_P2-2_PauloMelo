using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementLibrary.Models;

namespace UserManagementLibrary.Services
{

    /// <summary>
    /// Manages user data and provides methods to interact with the list of users.
    /// </summary>
    public class UserManager
    {

        #region Fields

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

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>The user with the specified username, or null if no user is found.</returns>
        public User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID, or null if no user is found.</returns>
        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Searches for users by their full name.
        /// </summary>
        /// <param name="fullName">The full name to search for.</param>
        /// <returns>An enumerable collection of users that match the search criteria.</returns>
        public IEnumerable<User> SearchUsersByFullName(string fullName)
        {
            return users.Where(u => u.FullName.IndexOf(fullName, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        #endregion
    }
}
