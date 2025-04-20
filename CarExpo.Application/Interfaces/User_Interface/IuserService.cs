using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Application.Dto.UserDto;
using CarExpo.Domain.Models.Users;
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

        Task<User> UpdateAsync(User user);

        Task<User> UpdateUserInfo(UpdateUserInformatiobCommand updateUserInfoCommand);

        Task<User?> ResetPassword(ResetPasswordCommand resetPasswordCommand);

        Task<User?> RecoverPassword(RecoverPasswordCommand recoverPasswordCommand);

        Task<User?> DeleteUser(DeleteCommand deleteCommand);

        Task<User?> SoftDelete(SoftDeleteCommand softDeleteCommand);

    }
}
