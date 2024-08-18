using System;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Utility;

/// <summary>
/// The main entry point for the application.
/// </summary>
class Program
{

    /// <summary>
    /// The main method that starts the application.
    /// </summary>
    static void Main()
    {
        ConsoleUtility.SetUnicodeConsole();
        UserManager userManager = new UserManager();
        User loggedInUser = null;

        while (true)
        {
            IUserMenu menu;

            if (loggedInUser == null)
            {
                var loginMenu = new LoginMenu(userManager);
                loginMenu.ShowMenu();

                // Atualiza o usuário logado após um login bem-sucedido
                loggedInUser = loginMenu.LoggedInUser;
            }
            else
            {
                // Exibe o menu baseado no tipo de usuário
                switch (loggedInUser.Role)
                {
                    case UserRole.Admin:
                        menu = new AdminMenu(userManager, loggedInUser);
                        break;
                    case UserRole.PowerUser:
                        menu = new PowerUserMenu(userManager, loggedInUser);
                        break;
                    case UserRole.SimpleUser:
                        menu = new SimpleUserMenu(userManager, loggedInUser);
                        break;
                    default:
                        throw new InvalidOperationException("Unknown user role.");
                }

                menu.ShowMenu();

                // Após a execução do menu, permita o logout ou finalize o programa
                loggedInUser = null; // Define como null para permitir novo login
            }
        }
    }
}
