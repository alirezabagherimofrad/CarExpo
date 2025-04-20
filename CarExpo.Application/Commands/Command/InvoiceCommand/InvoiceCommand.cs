using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.InvoiceCommand
{
    public class InvoiceCommand
    {
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
    }
}
