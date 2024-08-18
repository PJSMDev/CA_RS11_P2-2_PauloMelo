using System;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility;

class Program
{
    static UserManager userManager = new UserManager();
    static User loggedInUser;

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
                ShowUserMenu();
            }
        }
    }

    static void ShowLoginMenu()
    {
        ConsoleUtility.WriteTitle("Login Menu", ConsoleColor.Green, "\n", "\n");

        ConsoleUtility.WriteMessage("1. Login\n2. Exit", ConsoleColor.White, "\n", "\n\n");
        ConsoleUtility.WriteMessage("Select an option: ");
        Console.ResetColor(); // Reseta a cor para o padrão após o prompt

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
            ConsoleUtility.WriteTitle($"Welcome {loggedInUser.FullName}", GetUserColor(loggedInUser.Role), "", "\n");
            Console.Clear(); // Clear the screen after successful login
        }
        else
        {
            ConsoleUtility.WriteMessage("Invalid username or password. Try again.", ConsoleColor.Red, "\n", "\n");
        }
    }

    static void ShowUserMenu()
    {
        ConsoleUtility.WriteTitle("User Menu", GetUserColor(loggedInUser.Role), "", "\n\n");

        // Menus e prompts não coloridos, com espaçamento
        ConsoleUtility.WriteMessage("1. List Users\n2. Change Password\n3. Logout\n0. Exit", ConsoleColor.White, "", "\n\n");

        // Define o prompt com a cor do usuário logado
        Console.ForegroundColor = GetUserColor(loggedInUser.Role);
        Console.Write($"{loggedInUser.UserName}> ");
        Console.ResetColor(); // Reseta a cor para o padrão após o prompt

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                userManager.ListUsers();
                ConsoleUtility.PauseConsole();
                break;
            case "2":
                ChangePassword();
                break;
            case "3":
                loggedInUser = null;
                ConsoleUtility.WriteMessage("Logged out successfully.\n", ConsoleColor.Cyan);
                ConsoleUtility.PauseConsole();
                break;
            case "0":
                Environment.Exit(0);
                break;
            default:
                ConsoleUtility.WriteMessage("Invalid option. Please try again.\n", ConsoleColor.Red);
                ConsoleUtility.PauseConsole();
                break;
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

    static void ChangePassword()
    {
        ConsoleUtility.WriteTitle("Change Password", GetUserColor(loggedInUser.Role), "\n\n", "\n");

        ConsoleUtility.WriteMessage("Enter new password: ", GetUserColor(loggedInUser.Role));
        string newPassword = ConsoleUtility.ReadPassword();

        // Aqui você pode adicionar a lógica para atualizar a senha no UserManager

        ConsoleUtility.WriteMessage("Password changed successfully.\n", ConsoleColor.Green);
        ConsoleUtility.PauseConsole();
        Console.Clear();
    }
}
