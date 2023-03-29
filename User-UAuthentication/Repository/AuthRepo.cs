using Azure;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using User_UAuthentication.DataAccess;
using User_UAuthentication.Models;
using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.Repository
{
    public class AuthRepo : IAuth
    {
        private readonly UserUAuthContext _context;

        private readonly IConfiguration _configuration;

        public AuthRepo(UserUAuthContext context)
        {
            _context = context;
        }

        public AuthResultsDto login(UserLoginRequestDTO user)
        {
            var requestUser = _context.Users
                 .Include(u => u.refreshToken)
                 .FirstOrDefault(u => u.Email == user.Email);


            if (requestUser == null)
            {

                return new AuthResultsDto()
                {
                    Errors = new List<string>() {
                    "User not found"}
                };

                
            }

            if (!VerifyPasswordHash(user.Password, requestUser.PasswordHash, requestUser.PasswordSalt))
            {
                return new AuthResultsDto()
                {
                    Errors = new List<string>()
                    {
                       
                            "Password is incorrect"
                        
                    }
                };
            }


            //var (accessToken, refreshToken) = CreateToken(requestUser);

            // Generate access token
            //var accessToken = CreateToken(user);

            //Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            //{
            //    HttpOnly = true,
            //    Expires = DateTime.UtcNow.AddMinutes(5),
            //    SameSite = SameSiteMode.None,
            //    Secure = true
            //});

            //not-mandatory-to-return-refreshToken...it will be in cookies..anyway}
            var token = GenerateJwtToken(requestUser);
            return new AuthResultsDto()
            {
                accessToken = token,
                Result = true,
                Role = requestUser.Role,
                UserId = requestUser.UserId,
                UserName = requestUser.UserName
            };
        }

        public string register(UserRegisterDto newUser)
        {
           
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                return "User already exists.";
            }

            CreatePasswordHash(newUser.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt);

            var user = new User
            {
                UserName = newUser.UserName,
                Email = newUser.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken(),
                Role = "User",
                Address = newUser.Address,
                City = newUser.City,
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return "User successfully created!";
        }

        public string forgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == forgotPasswordDTO.Email);
            if (user == null)
            {
                return "User not found.";
            }

            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            _context.SaveChanges();
            return "Token has been Generated, reset your password using that token.";
        }

        public string resetPassword(ResetPasswordRequestDto resetPassword)
        {
            var user = _context.Users.FirstOrDefault(u => u.PasswordResetToken == resetPassword.Token);
            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return "Invalid Token.";
            }

            CreatePasswordHash(resetPassword.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            _context.SaveChanges();

            return "Password successfully reset.";
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateRandomToken()
        {


            // Generate a random 8-digit hex string
            byte[] randomBytes = new byte[4];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            string hexString = BitConverter.ToString(randomBytes).Replace("-", string.Empty);

            // Output the hex string
            return hexString;
        }

        //private (string accessToken, string refreshToken) CreateToken(User user)
        //{

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DqPysgL3U37XtJLjA9jgcXRAcww85DvQs0RbdBw2"));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
        //    new Claim(ClaimTypes.Role, user.Role),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
        //    new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"])
        //};

        //    var accessToken = new JwtSecurityToken(
        //        issuer: _configuration["Issuer"],
        //        audience: _configuration["Audience"],
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(20),
        //        signingCredentials: credentials
        //        );
        //    var refreshToken = new RefreshToken
        //    {
        //        Token = Guid.NewGuid().ToString(),
        //        UserId = user.UserId,
        //        Expires = DateTime.UtcNow.AddMinutes(40)
        //    };

        //    var refreshTokenValue = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
        //            expires: refreshToken.Expires,
        //            signingCredentials: credentials
        //         ));

        //    user.refreshToken = refreshToken;

        //    _context.RefreshTokens.Add(refreshToken);

        //    _context.Users.Update(user);

        //    _context.SaveChanges();
        //    return (new JwtSecurityTokenHandler().WriteToken(accessToken), refreshTokenValue);
        //}
        private string GenerateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("DqPysgL3U37XtJLjA9jgcXRAcww85DvQs0RbdBw2");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role)
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = credentials,
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        
    }
}
