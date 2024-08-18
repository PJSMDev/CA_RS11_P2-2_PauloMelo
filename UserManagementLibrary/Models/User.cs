namespace UserManagementLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserProfile Profile { get; set; }

        public User(int id, string username, string password, UserProfile profile)
        {
            Id = id;
            Username = username;
            Password = password;
            Profile = profile;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Username: {Username}, Profile: {Profile}";
        }
    }

    public enum UserProfile
    {
        Admin,
        PowerUser,
        SimpleUser
    }
}
