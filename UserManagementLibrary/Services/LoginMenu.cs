using System;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Models;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
{
    /// <summary>
    /// Represents the login menu for the application.
    /// </summary>
    public class LoginMenu : IUserMenu
    {
        private readonly UserManager userManager;
        private User loggedInUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginMenu"/> class.
        /// </summary>
        /// <param name="userManager">The user manager to handle user operations.</param>
        public LoginMenu(UserManager userManager)
        {
            this.userManager = userManager;
        }

        #region Properties

        /// <summary>
        /// Gets the currently logged-in user.
        /// </summary>
        public User LoggedInUser => loggedInUser;

        #endregion

        #region Menu Methods

        /// <summary>
        /// Displays the login menu and handles user input.
        /// </summary>
        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Login Menu", ConsoleColor.Green);

            while (true)
            {
                ConsoleUtility.WriteMessage("1. Enter Username\n2. Exit", ConsoleColor.White, "", "\n");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HandleLogin();
                        if (loggedInUser != null)
                        {
                            return; // Exit the menu if login is successful
                        }
                        break;

                    case "2":
                        ConsoleUtility.TerminateConsole();
                        Environment.Exit(0); // Ensure the application exits
                        break;

                    default:
                        ConsoleUtility.WriteMessage("Invalid option. Please try again.", ConsoleColor.Red, "\n", "\n");
                        ConsoleUtility.PauseConsole();
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the login process for the user.
        /// </summary>
        private void HandleLogin()
        {
            Console.Clear();

            ConsoleUtility.WriteTitle("Login", ConsoleColor.Green);

            ConsoleUtility.WriteMessage("Enter Username: ");
            string username = Console.ReadLine();

            ConsoleUtility.WriteMessage("Enter password: ");
            string password = ConsoleUtility.ReadPassword();

            User user = userManager.GetUser(username);

            if (user != null && user.Password == password)
            {
                loggedInUser = user;
                ConsoleUtility.WriteMessage($"Welcome, {user.FullName}!", ConsoleColor.Green, "\n", "\n");
                ConsoleUtility.PauseConsole();
            }
            else
            {
                ConsoleUtility.WriteMessage("Invalid username or password.", ConsoleColor.Red, "\n", "\n");
                ConsoleUtility.PauseConsole(); // Pause before retrying
            }
        }

        #endregion
    }
}
