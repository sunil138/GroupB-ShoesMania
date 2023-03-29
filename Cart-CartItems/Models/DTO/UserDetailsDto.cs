using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cart_CartItems.Models.DTO
{
    public class UserDetailsDto
    {
        public int userId { get; set; }

        public string? userName { get; set; }

        [JsonIgnore]
        public byte[] passwordHash { get; set; } = new byte[32];

        [JsonIgnore]
        public byte[] passwordSalt { get; set; } = new byte[32];
       
        [JsonIgnore]
        public string? verificationToken { get; set; }
        [JsonIgnore]
        public DateTime? verifiedAt { get; set; }
        [JsonIgnore]
        public string? passwordResetToken { get; set; }
        [JsonIgnore]
        public DateTime? resetTokenExpires { get; set; }


        public string? email { get; set; }

        public string? role { get; set; }
        public string? city { get; set; }
        public string? address { get; set; }

        [JsonIgnore]
        public string? refreshToken { get; set; }

       
    }
}
