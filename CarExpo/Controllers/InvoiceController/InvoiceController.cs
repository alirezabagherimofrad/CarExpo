using CarExpo.Application.Commands.Command.InvoiceCommand;
using CarExpo.Application.Interfaces.Invoice__Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.InvoiceController
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("Invoice")]
        public async Task<IActionResult> InvoiceAsync(InvoiceCommand invoiceCommand)
        {
            var result = await _invoiceService.Payment(invoiceCommand);
            return Ok(result);
        }
    }
}
