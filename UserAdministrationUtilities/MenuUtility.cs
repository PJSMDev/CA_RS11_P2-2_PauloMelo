using System;
using UserAdministration; // Namespace correto para acessar classes do projeto principal

namespace UserAdministration.Utilities
{
    /// <summary>
    /// Utility class for handling menu operations based on user roles.
    /// </summary>
    public static class MenuUtility
    {
        public static void RunMenuForUser(User user, IUserService userService)
        {
            switch (user.Role)
            {
                case UserRole.Admin:
                    RunAdminMenu(user, userService);
                    break;
                case UserRole.PowerUser:
                    RunPowerUserMenu(user, userService);
                    break;
                case UserRole.SimpleUser:
                    RunSimpleUserMenu(user, userService);
                    break;
            }
        }

        #region Private Methods

        private static void RunAdminMenu(User user, IUserService userService)
        {
            ConsoleUtility.WriteTitle("Admin Menu", $"Welcome {user.FullName},", $"Logged in as {user.Username}");

            // Implementation of the Admin menu here...
        }

        private static void RunPowerUserMenu(User user, IUserService userService)
        {
            ConsoleUtility.WriteTitle("Power User Menu", $"Welcome {user.FullName},", $"Logged in as {user.Username}");

            // Implementation of the Power User menu here...
        }

        private static void RunSimpleUserMenu(User user, IUserService userService)
        {
            ConsoleUtility.WriteTitle("Simple User Menu", $"Welcome {user.FullName},", $"Logged in as {user.Username}");

            // Implementation of the Simple User menu here...
        }

        #endregion
    }
}
