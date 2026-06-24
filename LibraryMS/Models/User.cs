using System.Data;

namespace LibraryMS.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; } = "";

        public string PasswordHash { get; set; } = "";

        public string? Email { get; set; }

        public int RoleID { get; set; }

        public Role? Role { get; set; }
    }
}
