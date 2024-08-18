namespace UserManagementLibrary.Models
{
    public enum UserRole
    {
        Admin,
        PowerUser,
        SimpleUser
    }

    public class User
    {
        public string FullName { get; set; } // Nome completo do usuário
        public string UserName { get; set; } // Nome de login do usuário
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
