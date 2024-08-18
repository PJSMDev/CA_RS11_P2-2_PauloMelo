namespace UserAdministration.Services
{
    /// <summary>
    /// Interface for user service operations.
    /// </summary>
    public interface IUserService
    {
        User AuthenticateUser();
        void CreateDefaultUsers();
        void AddUser(User user);
        void UpdateUser(string username, string newPassword, UserRole newRole);
        User GetUserById(int id);
        User GetUserByUsername(string username);
        List<User> GetUsersByRole(UserRole role);
        List<User> GetAllUsers();
    }
}
