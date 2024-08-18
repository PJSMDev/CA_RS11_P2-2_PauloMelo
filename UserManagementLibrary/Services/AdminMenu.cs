using System;
using UserManagementLibrary.Models;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
{
    public class AdminMenu : IUserMenu
    {
        private UserManager userManager;
        private User loggedInUser;

        public AdminMenu(UserManager userManager, User loggedInUser)
        {
            this.userManager = userManager;
            this.loggedInUser = loggedInUser;
        }

        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Admin Menu", ConsoleColor.Blue, "\n", "\n");
            ConsoleUtility.WriteMessage("1. Create User\n2. Update User\n3. Search User by ID\n4. Search User by Full Name\n5. List Users\n6. Logout\n0. Exit", ConsoleColor.White, "", "\n\n");

            HandleUserInput();
        }

        private void HandleUserInput()
        {
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                // Implementar opções específicas para o Admin
                case "6":
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
