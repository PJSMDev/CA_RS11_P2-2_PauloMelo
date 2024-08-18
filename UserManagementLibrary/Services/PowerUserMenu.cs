using System;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Models;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
{
    public class PowerUserMenu : IUserMenu
    {
        private readonly UserManager userManager;
        private readonly User loggedInUser;

        public PowerUserMenu(UserManager userManager, User loggedInUser)
        {
            this.userManager = userManager;
            this.loggedInUser = loggedInUser;
        }

        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Power User Menu", ConsoleColor.Magenta);

            while (true)
            {
                ConsoleUtility.WriteMessage("1. Search Users by Username\n2. Exit\n", ConsoleColor.White, "", "\n\n");

                Console.ForegroundColor = ConsoleColor.Magenta; // Cor do prompt para Power User
                Console.Write($"{loggedInUser.UserName}> ");
                Console.ResetColor(); // Restaura a cor padrão após o prompt

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SearchUsersByUsername();
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

        private void SearchUsersByUsername()
        {
            ConsoleUtility.WriteMessage("Enter username to search: ");
            string username = Console.ReadLine();

            var user = userManager.GetUser(username); // Buscar usuário pelo nome de usuário

            if (user != null)
            {
                ConsoleUtility.WriteTitle("User Found", ConsoleColor.Magenta);
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
                // Back to Power User Menu
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
    }
}
