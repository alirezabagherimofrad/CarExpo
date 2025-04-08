using CarExpo.Application.Commands.Command.VehicleCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.CommandValidator.VehicleCommandValidator
{
    public class EditCarInfoCommandValidator : AbstractValidator<EditCarInfoCommand>
    {
        public string LicensePlate { get; set; }
        public string VIN { get; set; }
        public EditCarInfoCommandValidator()
        {
            RuleFor(c => c.LicensePlate).Matches(@"^\d{2} [ا-ی] \d{3} ایران \d{2}$").WithMessage("پلاک وارد شده صحیح نمی باشد");

            RuleFor(c => c.VIN).Matches(@"^[A-HJ-NPR-Z0-9]{17}$").WithMessage("شماره شاسی وارد شده معتبر نیست. باید 17 کاراکتر از حروف و اعداد باشد");
        }
    }
}
