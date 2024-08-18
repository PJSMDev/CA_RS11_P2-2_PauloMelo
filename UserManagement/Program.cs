using System;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility;

class Program
{
    static UserManager userManager = new UserManager();
    static User loggedInUser;
    static IUserMenu userMenu;

    static void Main()
    {
        ConsoleUtility.SetUnicodeConsole();

        while (true)
        {
            if (loggedInUser == null)
            {
                ShowLoginMenu();
            }
            else
            {
                userMenu.ShowMenu();
            }
        }
    }

    static void ShowLoginMenu()
    {
        ConsoleUtility.WriteTitle("Login Menu", ConsoleColor.Green, "\n", "\n");

        ConsoleUtility.WriteMessage("1. Login\n2. Exit", ConsoleColor.White, "\n", "\n\n");
        ConsoleUtility.WriteMessage("Select an option: ");
        Console.ResetColor();

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                PerformLogin();
                break;
            case "2":
                Environment.Exit(0);
                break;
            default:
                ConsoleUtility.WriteMessage("Invalid option. Please try again.", ConsoleColor.Red, "", "\n");
                ConsoleUtility.PauseConsole();
                Console.Clear();
                break;
        }
    }

    static void PerformLogin()
    {
        Console.Clear();
        ConsoleUtility.WriteTitle("Login", ConsoleColor.Green, "\n", "\n");
        ConsoleUtility.WriteMessage("Enter Username: ", ConsoleColor.White);
        string username = Console.ReadLine();
        ConsoleUtility.WriteMessage("Enter Password: ", ConsoleColor.White);
        string password = ConsoleUtility.ReadPassword();

        var user = userManager.GetUser(username);

        if (user != null && user.Password == password)
        {
            loggedInUser = user;
            SetUserMenu(loggedInUser.Role); // Configura o menu com base no tipo de usuário
            ConsoleUtility.WriteTitle($"Welcome {loggedInUser.FullName}", GetUserColor(loggedInUser.Role), "", "\n");
            Console.Clear();
        }
        else
        {
            ConsoleUtility.WriteMessage("Invalid username or password. Try again.", ConsoleColor.Red, "\n", "\n");
        }
    }

    static void SetUserMenu(UserRole role)
    {
        switch (role)
        {
            case UserRole.Admin:
                userMenu = new AdminMenu(userManager, loggedInUser);
                break;
            case UserRole.PowerUser:
                userMenu = new PowerUserMenu(userManager, loggedInUser);
                break;
            case UserRole.SimpleUser:
                userMenu = new SimpleUserMenu(userManager, loggedInUser);
                break;
            default:
                throw new InvalidOperationException("Unknown user role.");
        }
    }

    static ConsoleColor GetUserColor(UserRole role)
    {
        switch (role)
        {
            case UserRole.Admin:
                return ConsoleColor.Blue;
            case UserRole.PowerUser:
                return ConsoleColor.Yellow;
            case UserRole.SimpleUser:
                return ConsoleColor.Cyan;
            default:
                return ConsoleColor.White;
        }
    }
}
