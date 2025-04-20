using CarExpo.Application.Commands.Command.PaymentRequestCommand;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.Loyalty_Interface
{
    public interface ILoyaltyService
    {
        Task<User> ApplyLoyalty(PaymentRequestCommand paymentRequestCommand);
    }
}
