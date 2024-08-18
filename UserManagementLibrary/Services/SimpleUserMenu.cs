using System;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
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

            // Exemplo de operação de menu
            Console.WriteLine("1. View your profile");
            Console.WriteLine("2. Update your details");
            // Adicionar lógica para cada opção

            ConsoleUtility.PauseConsole();
        }
    }
}
