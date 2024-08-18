﻿using System;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility;

namespace UserManagementLibrary.Services
{
    public class PowerUserMenu : IUserMenu
    {
        private readonly UserManager userManager;
        private readonly User loggedInUser;

        public PowerUserMenu(UserManager userManager, User loggedInUser)
        {
            this.userManager = userManager;
            this.loggedInUser = loggedInUser;
        }

        public void ShowMenu()
        {
            ConsoleUtility.WriteTitle("Power User Menu", ConsoleColor.Cyan);

            // Exemplo de operação de menu
            Console.WriteLine("1. View your details");
            Console.WriteLine("2. Perform actions");
            // Adicionar lógica para cada opção

            ConsoleUtility.PauseConsole();
        }
    }
}
