namespace UserAdministration.Services
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        public string FullName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public User(string fullName, string username, string password, UserRole role)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
