using System;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
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

            // Exemplo de operação de menu
            Console.WriteLine("1. View all users");
            Console.WriteLine("2. Search users");
            // Adicionar lógica para cada opção

            ConsoleUtility.PauseConsole();
        }
    }
}
