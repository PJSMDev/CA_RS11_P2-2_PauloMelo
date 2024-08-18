using System;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Models;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
{

    /// <summary>
    /// Represents the menu for simple users.
    /// </summary>
    public class SimpleUserMenu : IUserMenu
    {
        private readonly UserManager userManager;
        private readonly User loggedInUser;

        public SimpleUserMenu(UserManager userManager, User loggedInUser)
        {
            this.userManager = userManager;
            this.loggedInUser = loggedInUser;
        }

        #region Menu Methods

        /// <summary>
        /// Displays the simple user menu and handles user input.
        /// </summary>
        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Simple User Menu", ConsoleColor.Gray);

            while (true)
            {
                ConsoleUtility.WriteMessage("1. List Users\n2. Exit\n", ConsoleColor.White, "", "\n\n");

                Console.ForegroundColor = ConsoleColor.Gray; // Cor do prompt para Simple User
                Console.Write($"{loggedInUser.UserName}> ");
                Console.ResetColor(); // Restaura a cor padrão após o prompt

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListUsers();
                        break;
                    case "2":
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
        private void ListUsers()
        {
            var users = userManager.GetAllUsers(); // Obtem todos os utilizadores
            if (users != null)
            {
                Console.Clear();
                ConsoleUtility.WriteTitle("List of Users", ConsoleColor.Gray);

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
                // Back to Simple User Menu
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
