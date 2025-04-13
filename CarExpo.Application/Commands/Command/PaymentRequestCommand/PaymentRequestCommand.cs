using CarExpo.Application.Commands.CommandValidator.PaymentCommandValidator;
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.PaymentRequestCommand
{
    public class PaymentRequestCommand
    {
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public string? CardNumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public void Validate()
        {
            if (!new PaymentRequestCommandValidator().Validate(this).IsValid)
            {
                var eror = new PaymentRequestCommandValidator().Validate(this).Errors.FirstOrDefault();
                throw new Exception($"{eror.ErrorMessage}");
            }
        }
    }
}
