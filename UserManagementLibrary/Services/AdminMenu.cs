using System;
using System.Linq;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Menus
{
    public class AdminMenu : IUserMenu
    {
        private readonly UserManager userManager;
        private readonly User loggedInUser;

        public AdminMenu(UserManager userManager, User loggedInUser)
        {
            this.userManager = userManager;
            this.loggedInUser = loggedInUser;
        }

        public void ShowMenu()
        {
            while (true)
            {
                ConsoleUtility.WriteTitle("Admin Menu", ConsoleColor.Cyan);

                Console.WriteLine("1. View all users");
                Console.WriteLine("2. Search users");
                Console.WriteLine("3. Logout");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllUsers();
                        break;
                    case "2":
                        SearchUsers();
                        break;
                    case "3":
                        ConsoleUtility.WriteMessage("Logging out...", ConsoleColor.Green);
                        ConsoleUtility.PauseConsole();
                        return; // Exit the menu and log out
                    default:
                        ConsoleUtility.WriteMessage("Invalid option, please try again.", ConsoleColor.Red);
                        ConsoleUtility.PauseConsole();
                        break;
                }
            }
        }

        private void ViewAllUsers()
        {
            ConsoleUtility.WriteTitle("All Users", ConsoleColor.Yellow);

            var users = userManager.GetAllUsers(); // This method should be available in UserManager

            if (users.Any())
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"Username: {user.UserName}, Full Name: {user.FullName}, Role: {user.Role}");
                }
            }
            else
            {
                ConsoleUtility.WriteMessage("No users found.", ConsoleColor.Red);
            }

            ConsoleUtility.PauseConsole();
        }

        private void SearchUsers()
        {
            ConsoleUtility.WriteTitle("Search Users", ConsoleColor.Yellow);

            Console.Write("Enter username to search: ");
            string username = Console.ReadLine();

            User user = userManager.GetUser(username);

            if (user != null)
            {
                Console.WriteLine($"Username: {user.UserName}, Full Name: {user.FullName}, Role: {user.Role}");
            }
            else
            {
                ConsoleUtility.WriteMessage("User not found.", ConsoleColor.Red);
            }

            ConsoleUtility.PauseConsole();
        }
    }
}
