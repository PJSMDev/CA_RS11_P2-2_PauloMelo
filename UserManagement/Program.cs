using System;
using UserManagementLibrary.Menus;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility; // Para ConsoleUtility

class Program
{
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
                menu = new LoginMenu(userManager);
            }
            else
            {
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
            }

            menu.ShowMenu();
        }
    }
}
