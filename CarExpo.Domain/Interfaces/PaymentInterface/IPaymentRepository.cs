using CarExpo.Domain.Interfaces.IGenericInterface;
using CarExpo.Domain.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces.PaymentInterface
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
    }
}
