using System;
using UserManagementLibrary.Models;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
{
    public class SimpleUserMenu : IUserMenu
    {
        private UserManager userManager;
        private User loggedInUser;

        public SimpleUserMenu(UserManager userManager, User loggedInUser)
        {
            this.userManager = userManager;
            this.loggedInUser = loggedInUser;
        }

        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Simple User Menu", ConsoleColor.Cyan, "\n", "\n");
            ConsoleUtility.WriteMessage("1. List Users\n2. Logout\n0. Exit", ConsoleColor.White, "", "\n\n");

            HandleUserInput();
        }

        private void HandleUserInput()
        {
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                // Implementar opções específicas para o Simple User
                case "2":
                    // Logout logic
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    ConsoleUtility.WriteMessage("Invalid option. Please try again.\n", ConsoleColor.Red);
                    ConsoleUtility.PauseConsole();
                    break;
            }
        }
    }
}
