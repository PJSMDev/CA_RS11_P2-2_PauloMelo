using System;
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
            ConsoleUtility.WriteTitle("Admin Menu", ConsoleColor.Cyan);

            while (true)
            {
                ConsoleUtility.WriteMessage("1. View All Users", ConsoleColor.Cyan);
                ConsoleUtility.WriteMessage("2. Search Users by Name", ConsoleColor.Cyan);
                ConsoleUtility.WriteMessage("3. Create User", ConsoleColor.Cyan);
                ConsoleUtility.WriteMessage("4. Update User Profile", ConsoleColor.Cyan);
                ConsoleUtility.WriteMessage("5. Exit", ConsoleColor.Cyan);

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllUsers();
                        break;
                    case "2":
                        SearchUsersByName();
                        break;
                    case "3":
                        CreateUser();
                        break;
                    case "4":
                        UpdateUserProfile();
                        break;
                    case "5":
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

        private void SearchUsersByName()
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();
            var users = userManager.SearchUsersByFullName(name);

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, FullName: {user.FullName}, Username: {user.UserName}, Role: {user.Role}");
            }
            ConsoleUtility.PauseConsole();
        }

        private void CreateUser()
        {
            // Implementation for creating a user
        }

        private void UpdateUserProfile()
        {
            // Implementation for updating user profile
        }
    }
}
