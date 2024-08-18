using System;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Models;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
{

    /// <summary>
    /// Represents the menu for administrators.
    /// </summary>
    public class AdminMenu : IUserMenu
    {
        private readonly UserManager userManager;
        private readonly User loggedInUser;

        public AdminMenu(UserManager userManager, User loggedInUser)
        {
            this.userManager = userManager;
            this.loggedInUser = loggedInUser;
        }

        #region Menu Methods

        /// <summary>
        /// Displays the admin menu and handles user input.
        /// </summary>
        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Admin Menu", ConsoleColor.Cyan);

            while (true)
            {
                ConsoleUtility.WriteMessage("1. View All Users\n2. Search Users by Username\n3. Exit", ConsoleColor.White, "", "\n\n");

                Console.ForegroundColor = ConsoleColor.Cyan; // Cor do prompt para Admin
                Console.Write($"{loggedInUser.UserName}> ");
                Console.ResetColor(); // Restaura a cor padrão após o prompt

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllUsers();
                        break;
                    case "2":
                        SearchUsersByUsername();
                        break;
                    case "3":
                        ConsoleUtility.TerminateConsole();
                        return;
                    default:
                        ConsoleUtility.WriteMessage("Invalid option. Please try again.", ConsoleColor.Red, "\n", "\n");
                        ConsoleUtility.PauseConsole();
                        break;
                }
            }
        }

        /// <summary>
        /// Displays all users.
        /// </summary>
        private void ViewAllUsers()
        {
            var users = userManager.GetAllUsers(); // Obtem todos os utilizadores
            if (users != null)
            {
                ConsoleUtility.WriteTitle("All Users", ConsoleColor.Cyan);

                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id}, FullName: {user.FullName}, Username: {user.UserName}, Role: {user.Role}");
                }
            }
            else
            {
                ConsoleUtility.WriteMessage("No users found.", ConsoleColor.Yellow, "\n", "\n");
            }

            ConsoleUtility.WriteMessage("1. Back\n2. Exit", ConsoleColor.White, "", "\n\n");
            Console.Write($"{loggedInUser.UserName}> ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Back to Admin Menu
                return;
            }
            else if (choice == "2")
            {
                ConsoleUtility.TerminateConsole();
                Environment.Exit(0); // Exit the application
            }
            else
            {
                ConsoleUtility.WriteMessage("Invalid option. Please try again.", ConsoleColor.Red, "\n", "\n");
                ConsoleUtility.PauseConsole();
            }
        }

        /// <summary>
        /// Searches for users by username and displays the result.
        /// </summary>
        private void SearchUsersByUsername()
        {
            ConsoleUtility.WriteMessage("Enter username to search: ");
            string username = Console.ReadLine();

            var user = userManager.GetUser(username); // Buscar usuário pelo nome de usuário

            if (user != null)
            {
                ConsoleUtility.WriteTitle("User Found", ConsoleColor.Cyan);
                Console.WriteLine($"ID: {user.Id}, FullName: {user.FullName}, Username: {user.UserName}, Role: {user.Role}");
            }
            else
            {
                ConsoleUtility.WriteMessage("User not found.", ConsoleColor.Red, "\n", "\n");
            }

            ConsoleUtility.WriteMessage("1. Back\n2. Exit", ConsoleColor.White, "", "\n\n");
            Console.Write($"{loggedInUser.UserName}> ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Back to Admin Menu
                return;
            }
            else if (choice == "2")
            {
                ConsoleUtility.TerminateConsole();
                Environment.Exit(0); // Exit the application
            }
            else
            {
                ConsoleUtility.WriteMessage("Invalid option. Please try again.", ConsoleColor.Red, "\n", "\n");
                ConsoleUtility.PauseConsole();
            }
        }

        #endregion
    }
}
