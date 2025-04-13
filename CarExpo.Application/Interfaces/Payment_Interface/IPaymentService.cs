using CarExpo.Application.Commands.Command.PaymentRequestCommand;
using CarExpo.Domain.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.Payment_Interface
{
    public interface IPaymentService
    {
        Task<Payment> Payment(PaymentRequestCommand paymentRequestService);

    }

}
