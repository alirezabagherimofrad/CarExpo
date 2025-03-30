using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command
{
    public class RegisterCommand
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

    }
}
