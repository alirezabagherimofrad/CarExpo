using CarExpo.Application.Commands.Command.UserCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.CommandValidator.UserCommandValidator
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public RegisterCommandValidator()
        {

            RuleFor(x => x.Email)
            .Matches(new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            .WithMessage("لطفاً یک ایمیل معتبر وارد کنید.")
            .Must(email => email.Contains("@")).WithMessage("ایمیل باید شامل '@' باشد.")
            .Must(email => email.Split('@').Length == 2 && email.Split('@')[1].Contains("."))
            .WithMessage("ایمیل باید دامنه‌ای معتبر بعد از '@' داشته باشد.")
            .Matches(@"^[a-zA-Z0-9@._-]+$")
            .WithMessage("ایمیل باید شامل فقط حروف، اعداد و کاراکترهای خاص مثل @، .، _ و - باشد.");

            RuleFor(request => request.Password)
            .NotEmpty().WithMessage("رمز عبور نباید خالی باشد.")
            .MinimumLength(8).WithMessage("رمز عبور باید حداقل ۸ کاراکتر داشته باشد.")
            .Matches("[A-Z]").WithMessage("رمز عبور باید حداقل یک حرف بزرگ انگلیسی داشته باشد.")
            .Matches("[a-z]").WithMessage("رمز عبور باید حداقل یک حرف کوچک انگلیسی داشته باشد.")
            .Matches(@"\d").WithMessage("رمز عبور باید حداقل یک عدد داشته باشد.")
            .Matches(@"[!@#$%^&*(),.?""{}|<>]").WithMessage("رمز عبور باید حداقل یک کاراکتر خاص داشته باشد.");

            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("شماره را وارد کنید")
           .Matches(new Regex(@"^(?:(?:\+98)|(?:0))9\d{9}$"))
           .WithMessage("شماره تلفن وارد شده صحیح نیست لطفا شماره درست وارد کنید");

        }
    }
}
