using System;
using UserManagementLibrary.Models;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
{
    public class PowerUserMenu : IUserMenu
    {
        private UserManager userManager;
        private User loggedInUser;

        public PowerUserMenu(UserManager userManager, User loggedInUser)
        {
            this.userManager = userManager;
            this.loggedInUser = loggedInUser;
        }

        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Power User Menu", ConsoleColor.Yellow, "\n", "\n");
            ConsoleUtility.WriteMessage("1. Search User by Full Name\n2. List Users\n3. Logout\n0. Exit", ConsoleColor.White, "", "\n\n");

            HandleUserInput();
        }

        private void HandleUserInput()
        {
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                // Implementar opções específicas para o Power User
                case "3":
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
