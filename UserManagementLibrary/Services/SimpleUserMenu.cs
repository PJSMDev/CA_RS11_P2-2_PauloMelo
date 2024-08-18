using System;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Menus
{
    public class SimpleUserMenu : IUserMenu
    {
        private readonly UserManager userManager;
        private readonly User loggedInUser;

        public SimpleUserMenu(UserManager userManager, User loggedInUser)
        {
            this.userManager = userManager;
            this.loggedInUser = loggedInUser;
        }

        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Simple User Menu", ConsoleColor.Cyan);

            while (true)
            {
                ConsoleUtility.WriteMessage("1. View All Users", ConsoleColor.Cyan);
                ConsoleUtility.WriteMessage("2. Exit", ConsoleColor.Cyan);

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllUsers();
                        break;
                    case "2":
                        return; // Exit the menu
                    default:
                        ConsoleUtility.WriteMessage("Invalid choice. Please try again.", ConsoleColor.Red);
                        ConsoleUtility.PauseConsole();
                        break;
                }
            }
        }

        private void ViewAllUsers()
        {
            var users = userManager.GetAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, FullName: {user.FullName}, Username: {user.UserName}, Role: {user.Role}");
            }
            ConsoleUtility.PauseConsole();
        }
    }
}
