﻿namespace UserManagementLibrary.Models
{
    public class User
    {
        public int Id { get; set; } // Adiciona a propriedade ID
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
