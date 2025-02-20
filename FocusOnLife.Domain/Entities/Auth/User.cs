using FocusOnLife.Domain.Enums;

namespace FocusOnLife.Domain.Entities.Auth
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRoles Role { get; set; } // Enum
    }
}
