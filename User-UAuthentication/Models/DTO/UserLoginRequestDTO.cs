using System.ComponentModel.DataAnnotations;

namespace User_UAuthentication.Models.DTO
{
    public class UserLoginRequestDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
