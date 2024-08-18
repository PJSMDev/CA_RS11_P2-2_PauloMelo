using System;
using UserManagementLibrary.Models;
using UserManagementLibrary.Services;
using UserManagementLibrary.Utility; // Ajuste para o namespace correto

namespace UserManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configura o console para usar UTF-8
            ConsoleUtility.SetUnicodeConsole();

            // Cria uma instância do UserManager
            var userManager = new UserManager();
            User loggedInUser = null;

            while (true)
            {
                Console.Clear();
                ConsoleUtility.WriteTitle("Login Menu", "Welcome to ", " Login System");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                if (choice == "2")
                    break;

                if (choice == "1")
                {
                    Console.Write("Username: ");
                    var username = Console.ReadLine();
                    Console.Write("Password: ");
                    var password = ConsoleUtility.ReadPassword();

                    loggedInUser = userManager.GetUserByUsername(username);

                    if (loggedInUser != null && loggedInUser.Password == password)
                    {
                        Console.Clear();
                        SetConsoleColorForProfile(loggedInUser.Profile);
                        ConsoleUtility.WriteTitle($"Logged in as {loggedInUser.Username} ({loggedInUser.Profile})");

                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("1. List Users");
                            if (loggedInUser.Profile == UserProfile.Admin)
                            {
                                Console.WriteLine("2. Add User");
                                Console.WriteLine("3. Remove User");
                                Console.WriteLine("4. Search User by ID");
                                Console.WriteLine("5. Search User by Username");
                            }
                            Console.WriteLine("0. Logout");
                            Console.Write("Choose an option: ");
                            var userChoice = Console.ReadLine();

                            if (userChoice == "0")
                                break;

                            switch (userChoice)
                            {
                                case "1":
                                    ListUsers(userManager);
                                    break;
                                case "2":
                                    if (loggedInUser.Profile == UserProfile.Admin)
                                        AddUser(userManager);
                                    else
                                        ConsoleUtility.WriteMessage("Permission denied.", "", "\n");
                                    break;
                                case "3":
                                    if (loggedInUser.Profile == UserProfile.Admin)
                                        RemoveUser(userManager);
                                    else
                                        ConsoleUtility.WriteMessage("Permission denied.", "", "\n");
                                    break;
                                case "4":
                                    if (loggedInUser.Profile == UserProfile.Admin)
                                        SearchUserById(userManager);
                                    else
                                        ConsoleUtility.WriteMessage("Permission denied.", "", "\n");
                                    break;
                                case "5":
                                    if (loggedInUser.Profile == UserProfile.Admin)
                                        SearchUserByUsername(userManager);
                                    else
                                        ConsoleUtility.WriteMessage("Permission denied.", "", "\n");
                                    break;
                                default:
                                    ConsoleUtility.WriteMessage("Invalid option.", "", "\n");
                                    break;
                            }

                            ConsoleUtility.PauseConsole();
                        }
                    }
                    else
                    {
                        ConsoleUtility.WriteMessage("Invalid credentials.", "", "\n");
                        ConsoleUtility.PauseConsole();
                    }
                }
            }

            ConsoleUtility.TerminateConsole();
        }

        static void SetConsoleColorForProfile(UserProfile profile)
        {
            switch (profile)
            {
                case UserProfile.Admin:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case UserProfile.PowerUser:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case UserProfile.SimpleUser:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
            }
        }

        static void ListUsers(UserManager userManager)
        {
            var users = userManager.ListUsers();
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }

        static void AddUser(UserManager userManager)
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = ConsoleUtility.ReadPassword();
            Console.Write("Profile (Admin, PowerUser, SimpleUser): ");
            var profile = (UserProfile)Enum.Parse(typeof(UserProfile), Console.ReadLine(), true);

            var user = new User(0, username, password, profile);
            userManager.AddUser(user);
            ConsoleUtility.WriteMessage("User added successfully.", "", "\n");
        }

        static void RemoveUser(UserManager userManager)
        {
            Console.Write("User ID: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                if (userManager.RemoveUser(id))
                    ConsoleUtility.WriteMessage("User removed successfully.", "", "\n");
                else
                    ConsoleUtility.WriteMessage("User not found.", "", "\n");
            }
            else
            {
                ConsoleUtility.WriteMessage("Invalid ID.", "", "\n");
            }
        }

        static void SearchUserById(UserManager userManager)
        {
            Console.Write("User ID: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var user = userManager.GetUserById(id);
                if (user != null)
                    Console.WriteLine(user);
                else
                    ConsoleUtility.WriteMessage("User not found.", "", "\n");
            }
            else
            {
                ConsoleUtility.WriteMessage("Invalid ID.", "", "\n");
            }
        }

        static void SearchUserByUsername(UserManager userManager)
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();
            var user = userManager.GetUserByUsername(username);
            if (user != null)
                Console.WriteLine(user);
            else
                ConsoleUtility.WriteMessage("User not found.", "", "\n");
        }
    }
}
