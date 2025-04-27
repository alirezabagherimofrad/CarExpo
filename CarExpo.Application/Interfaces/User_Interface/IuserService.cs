using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Application.Dto.UserDto;
using CarExpo.Domain.Models.Users;
using CarExpo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.User_Interface
{
    public interface IuserService
    {
        Task<RegisterDto> RegisterAsync(RegisterCommand registerCommand);

        Task<User> UpdateUserInfo(UpdateUserInformatiobCommand updateUserInfoCommand);

        Task<User?> ResetPassword(ResetPasswordCommand resetPasswordCommand);

        Task<User?> RecoverPassword(RecoverPasswordCommand recoverPasswordCommand);
        Task<AuthResult> LoginAsync(string email, string password);
        Task<bool> LoginWithOtpAsync(string phoneNumber, string password);
        Task<(bool Success, string? Token, string? Message)> VerifyOtpAsync(string phoneNumber, string code);

        Task<User?> DeleteUser(DeleteCommand deleteCommand);

        Task<User?> SoftDelete(SoftDeleteCommand softDeleteCommand);


    }
}
