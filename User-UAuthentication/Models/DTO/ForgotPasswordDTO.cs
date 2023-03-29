using System.ComponentModel.DataAnnotations;

namespace User_UAuthentication.Models.DTO
{
    public class ForgotPasswordDTO
    {

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
