namespace UserManagementLibrary.Models
{

    /// <summary>
    /// Represents the different roles a user can have in the system.
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Represents an administrator with full access.
        /// </summary>
        Admin,

        /// <summary>
        /// Represents a power user with elevated access.
        /// </summary>
        PowerUser,

        /// <summary>
        /// Represents a simple user with limited access.
        /// </summary>
        SimpleUser
    }
}
