using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.UserCommand
{
    public class UpdateUserInformatiobCommand
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Otp { get; set; }

    }
}
