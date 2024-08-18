using UserAdministration.Services;
using UserAdministration.Utilities;

namespace UserAdministration
{
    public static class ApplicationRunner
    {
        private static IUserService userService;

        static ApplicationRunner()
        {
            userService = new UserService();
        }

        /// <summary>
        /// Runs the main application logic.
        /// </summary>
        public static void RunApplication()
        {
            ConsoleUtility.SetUnicodeConsole();

            // Automatically create default users
            userService.CreateDefaultUsers();

            // Login and menu selection loop
            while (true)
            {
                Console.Clear();
                ConsoleUtility.WriteTitle("User Administration System");

                // Handle user login
                var loggedInUser = userService.AuthenticateUser();
                if (loggedInUser == null)
                {
                    ConsoleUtility.WriteMessage("\nInvalid credentials. Please try again.");
                    continue;
                }

                // Run menu based on user role
                MenuUtility.RunMenuForUser(loggedInUser, userService);
            }
        }
    }
}
