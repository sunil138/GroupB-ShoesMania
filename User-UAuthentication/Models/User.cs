using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_UAuthentication.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }

      

        public string? Email { get; set; }

       
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        [NotMapped]
        public string? VerificationToken { get; set; }
        [NotMapped]
        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }

        public DateTime? ResetTokenExpires { get; set; }
        public string? Role { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        //changed
        public RefreshToken refreshToken { get; set; }


    }
}
