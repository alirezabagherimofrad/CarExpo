using CarExpo.Application.Commands.Command.PaymentRequestCommand;
using CarExpo.Application.Interfaces.Email_Interface;
using CarExpo.Application.Interfaces.Payment_Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.PaymentController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentComtroller : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentComtroller(IPaymentService paymentComtroller)
        {
            _paymentService = paymentComtroller;
        }

        [HttpPost("PaymentRequest")]
        public async Task<IActionResult> PaymentRequestAsync(PaymentRequestCommand paymentRequestCommand)
        {
            var result = await _paymentService.Payment(paymentRequestCommand);
            return Ok(result);
        }
    }
}
