using System.ComponentModel.DataAnnotations;

namespace User_UAuthentication.Models.DTO
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }
        [Required, MinLength(4)]
        public string UserName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string? Role { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
    }
}
