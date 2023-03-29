using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.DataAccess
{
    public interface IAuth
    {
        AuthResultsDto login(UserLoginRequestDTO user);

        string register(UserRegisterDto newUser);

        string forgotPassword(ForgotPasswordDTO forgotPasswordDTO); 

        string resetPassword(ResetPasswordRequestDto resetPassword);
    }
}
