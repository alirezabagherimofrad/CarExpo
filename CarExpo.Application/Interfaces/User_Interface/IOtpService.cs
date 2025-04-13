using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.User_Interface
{
    public interface IOtpService
    {
        Task<User> SendOtp(SendOtpCommand sendOtpCommand);

        Task<User> VerifyOtp(VerifyOtpCommand verifyOtpCommand);
    }
}
