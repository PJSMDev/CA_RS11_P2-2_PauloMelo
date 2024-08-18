using System;
using UserManagementLibrary.Utility;
using User = UserManagementLibrary.Models.User;  // Usa o User do namespace Models
using UserRole = UserManagementLibrary.Models.UserRole;  // Usa o UserRole do namespace Models
using UserManagementLibrary.Services;

namespace UserManagement
{
    class Program
    {
        private static UserManager userManager;
        private static User currentUser;

        static void Main(string[] args)
        {
            ConsoleUtility.SetUnicodeConsole();
            userManager = new UserManager();

            // Criação dos usuários iniciais
            InitializeUsers();

            // Exemplo de login - pode ser substituído por uma funcionalidade de autenticação real
            Login();

            // Exibe o menu baseado no perfil do usuário
            ShowMenu();
        }

        private static void InitializeUsers()
        {
            // Usuários iniciais são criados no construtor do UserManager
        }

        private static void Login()
        {
            // Exemplo simples de login (deveria ser substituído por um processo real de autenticação)
            ConsoleUtility.WriteTitle("Login", "\n", "\n");
            ConsoleUtility.WriteMessage("Enter username: ", "", "");
            string userName = Console.ReadLine();
            ConsoleUtility.WriteMessage("Enter password: ", "", "");
            string password = ConsoleUtility.ReadPassword();

            // Verifica se o usuário existe e autentica (aqui é apenas um exemplo simples)
            currentUser = userManager.GetUser(userName);
            if (currentUser == null || currentUser.Password != password)
            {
                Console.WriteLine("Invalid credentials.");
                ConsoleUtility.TerminateConsole();
                return;
            }

            Console.WriteLine($"Welcome, {currentUser.FullName}!");
        }

        private static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                ConsoleUtility.WriteTitle($"{currentUser.Role} Menu", "\n", "\n");

                if (currentUser.Role == UserRole.Admin)
                {
                    ConsoleUtility.WriteMessage("1. Create User\n2. Search User\n3. List Users\n4. Exit\n", "", "");
                }
                else if (currentUser.Role == UserRole.PowerUser)
                {
                    ConsoleUtility.WriteMessage("1. Search User\n2. List Users\n3. Exit\n", "", "");
                }
                else if (currentUser.Role == UserRole.SimpleUser)
                {
                    ConsoleUtility.WriteMessage("1. List Users\n2. Exit\n", "", "");
                }

                ConsoleUtility.WriteMessage("Select an option: ", "", "");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        if (currentUser.Role == UserRole.Admin)
                        {
                            CreateUser();
                        }
                        else if (currentUser.Role == UserRole.PowerUser)
                        {
                            SearchUser();
                        }
                        else if (currentUser.Role == UserRole.SimpleUser)
                        {
                            ListUsers();
                        }
                        break;
                    case "2":
                        if (currentUser.Role == UserRole.Admin || currentUser.Role == UserRole.PowerUser)
                        {
                            SearchUser();
                        }
                        else if (currentUser.Role == UserRole.SimpleUser)
                        {
                            ListUsers();
                        }
                        break;
                    case "3":
                        if (currentUser.Role == UserRole.Admin || currentUser.Role == UserRole.PowerUser)
                        {
                            ListUsers();
                        }
                        break;
                    case "4":
                        ConsoleUtility.TerminateConsole();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void CreateUser()
        {
            ConsoleUtility.WriteMessage("Enter full name: ", "", "");
            string fullName = Console.ReadLine();
            ConsoleUtility.WriteMessage("Enter username: ", "", "");
            string userName = Console.ReadLine();
            ConsoleUtility.WriteMessage("Enter password: ", "", "");
            string password = ConsoleUtility.ReadPassword();
            ConsoleUtility.WriteMessage("Enter role (Admin, PowerUser, SimpleUser): ", "", "");
            string roleInput = Console.ReadLine();
            if (Enum.TryParse(roleInput, true, out UserRole role))  // Ignora maiúsculas/minúsculas
            {
                userManager.CreateUser(fullName, userName, password, role);
            }
            else
            {
                Console.WriteLine("Invalid role.");
            }
        }

        private static void SearchUser()
        {
            ConsoleUtility.WriteMessage("Enter username to search: ", "", "");
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
        }

        private static void ListUsers()
        {
            userManager.ListUsers();
        }
    }
}
