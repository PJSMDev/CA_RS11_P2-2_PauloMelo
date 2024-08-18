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

        public LoginMenu(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Login Menu", ConsoleColor.Cyan);

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = ConsoleUtility.ReadPassword();

            User user = userManager.GetUser(username);

            if (user != null && user.Password == password)
            {
                ConsoleUtility.WriteMessage($"Welcome, {user.FullName}!", ConsoleColor.Green);
                // Aqui você pode definir o usuário logado para uso posterior
            }
            else
            {
                ConsoleUtility.WriteMessage("Invalid username or password", ConsoleColor.Red);
            }

            ConsoleUtility.PauseConsole();
        }
    }
}
