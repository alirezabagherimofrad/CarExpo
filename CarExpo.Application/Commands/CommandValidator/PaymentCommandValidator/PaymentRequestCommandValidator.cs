using CarExpo.Application.Commands.Command.PaymentRequestCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.CommandValidator.PaymentCommandValidator
{
    public class PaymentRequestCommandValidator : AbstractValidator<PaymentRequestCommand>
    {
        public string? CardNumber { get; set; }
        public PaymentRequestCommandValidator()
        {
         RuleFor(x => x.CardNumber)
        .NotEmpty().WithMessage("شماره کارت الزامی است.")
        .Matches(@"^(603799|589210|627648|627961|603770|628023|627760|502908|627412|622106|502229|627488|621986|639346|639607|636214|502806|502938|603769|610433|627353|585983|589463|627381|639370|639599|505416|606373|507677|504172|636949|585947)\d{10}$")
        .WithMessage("شماره کارت باید ۱۶ رقمی و متعلق به یکی از بانک‌های معتبر ایران باشد.")
        .Must(CardNumberValidator.IsValidCardNumber)
        .WithMessage("شماره کارت نامعتبر است");
        }
    }
}