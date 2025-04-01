using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.UserCommand
{
    public class VerifyOtpCommand
    {
        public string PhoneNumber { get; set; }

        public string Otp { get; set; }
    }
}
