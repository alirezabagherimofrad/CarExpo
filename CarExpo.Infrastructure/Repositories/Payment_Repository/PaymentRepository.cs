using CarExpo.Domain.Interfaces.PaymentInterface;
using CarExpo.Domain.Models.Payment;
using CarExpo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Repositories.Payment_Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
