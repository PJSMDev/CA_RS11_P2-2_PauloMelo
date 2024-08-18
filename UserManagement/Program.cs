using System;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility;

namespace UserManagement
{
    class Program
    {
        private static UserManager userManager = new UserManager();
        private static User currentUser;

        static void Main(string[] args)
        {
            ConsoleUtility.SetUnicodeConsole();
            Login();
            ShowMainMenu();
        }

        private static void Login()
        {
            ConsoleUtility.WriteTitle("Login", ConsoleColor.Green, "", "\n");

            Console.Write("UserName: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = ConsoleUtility.ReadPassword();

            var user = userManager.GetUser(userName);

            if (user != null && user.Password == password)
            {
                currentUser = user;
                // Cor do cabeçalho conforme o perfil do usuário
                ConsoleColor welcomeColor = GetWelcomeColor(user.Role);
                ConsoleUtility.WriteTitle($"Welcome, {currentUser.FullName} ({currentUser.Role})", welcomeColor, "", "\n");
            }
            else
            {
                ConsoleUtility.WriteTitle("Invalid credentials", ConsoleColor.Red, "", "\n");
                ConsoleUtility.TerminateConsole();
                Environment.Exit(0);
            }
        }

        private static ConsoleColor GetWelcomeColor(UserRole role)
        {
            // Define a cor do cabeçalho com base no perfil do usuário
            switch (role)
            {
                case UserRole.Admin:
                    return ConsoleColor.Blue;
                case UserRole.PowerUser:
                    return ConsoleColor.Cyan;
                case UserRole.SimpleUser:
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.White; // Cor padrão se o perfil não for reconhecido
            }
        }

        private static void ShowMainMenu()
        {
            while (true)
            {
                switch (currentUser.Role)
                {
                    case UserRole.Admin:
                        ShowAdminMenu();
                        break;
                    case UserRole.PowerUser:
                        ShowPowerUserMenu();
                        break;
                    case UserRole.SimpleUser:
                        ShowSimpleUserMenu();
                        break;
                }
            }
        }

        private static void ShowAdminMenu()
        {
            ConsoleUtility.WriteTitle("Admin Menu", ConsoleColor.Blue, "", "\n");

            Console.WriteLine("1. Create User");
            Console.WriteLine("2. List Users");
            Console.WriteLine("3. Search User by UserName");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateUser();
                    break;
                case "2":
                    userManager.ListUsers();
                    ConsoleUtility.PauseConsole();
                    break;
                case "3":
                    SearchUser();
                    break;
                case "4":
                    ConsoleUtility.TerminateConsole();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private static void ShowPowerUserMenu()
        {
            ConsoleUtility.WriteTitle("Power User Menu", ConsoleColor.Cyan, "", "\n");

            Console.WriteLine("1. List Users");
            Console.WriteLine("2. Search User by UserName");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    userManager.ListUsers();
                    ConsoleUtility.PauseConsole();
                    break;
                case "2":
                    SearchUser();
                    break;
                case "3":
                    ConsoleUtility.TerminateConsole();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private static void ShowSimpleUserMenu()
        {
            ConsoleUtility.WriteTitle("Simple User Menu", ConsoleColor.Yellow, "", "\n");

            Console.WriteLine("1. List Users");
            Console.WriteLine("2. Exit");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    userManager.ListUsers();
                    ConsoleUtility.PauseConsole();
                    break;
                case "2":
                    ConsoleUtility.TerminateConsole();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private static void CreateUser()
        {
            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = ConsoleUtility.ReadPassword();

            UserRole role;
            while (true)
            {
                Console.Write("Enter Role (Admin, PowerUser, SimpleUser): ");
                var roleInput = Console.ReadLine();

                if (Enum.TryParse(roleInput, true, out role) && Enum.IsDefined(typeof(UserRole), role))
                {
                    break;
                }
                Console.WriteLine("Invalid role. Try again.");
            }

            userManager.CreateUser(fullName, userName, password, role);
            ConsoleUtility.WriteTitle("User created successfully", ConsoleColor.Green);
            ConsoleUtility.PauseConsole();
        }

        private static void SearchUser()
        {
            Console.Write("Enter UserName to search: ");
            string userName = Console.ReadLine();
            var user = userManager.GetUser(userName);

            if (user != null)
            {
                Console.WriteLine($"Full Name: {user.FullName}, UserName: {user.UserName}, Role: {user.Role}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
            ConsoleUtility.PauseConsole();
        }
    }
}
