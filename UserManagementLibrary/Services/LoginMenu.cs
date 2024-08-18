using System;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
{
    public class LoginMenu : IUserMenu
    {
        private readonly UserManager userManager;
        private User loggedInUser;

        public LoginMenu(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public User LoggedInUser => loggedInUser;

        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Login Menu", ConsoleColor.Green); // Alterar cor para verde

            while (true)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = ConsoleUtility.ReadPassword();

                User user = userManager.GetUser(username);

                if (user != null && user.Password == password)
                {
                    loggedInUser = user;
                    ConsoleUtility.WriteMessage($"Welcome, {user.FullName}!", ConsoleColor.Green);
                    ConsoleUtility.PauseConsole();
                    return;  // Exit the loop and return to the caller
                }
                else
                {
                    ConsoleUtility.WriteMessage("Invalid username or password", ConsoleColor.Red);
                    ConsoleUtility.PauseConsole(); // Pause before retrying
                }
            }
        }
    }
}
