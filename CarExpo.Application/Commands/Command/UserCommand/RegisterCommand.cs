using CarExpo.Application.Commands.CommandValidation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.UserCommand
{
    public class RegisterCommand
    {

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public void Validate()
        {
            if (!new RegisterCommandValidator().Validate(this).IsValid)
            {
                var error = new RegisterCommandValidator().Validate(this).Errors.FirstOrDefault();
                throw new Exception($"{error.ErrorMessage}");
            }
        }

    }
}
