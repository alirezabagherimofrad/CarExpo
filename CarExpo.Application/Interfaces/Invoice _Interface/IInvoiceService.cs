using CarExpo.Application.Commands.Command.InvoiceCommand;
using CarExpo.Application.Dto.InvoiceDto;
using CarExpo.Application.Services.Invoice_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.Invoice__Interface
{
    public interface IInvoiceService
    {
        Task<InvoiceCommandDto> Payment(InvoiceCommand invoiceCommand);
    }
}
