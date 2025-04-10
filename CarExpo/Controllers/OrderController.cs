using CarExpo.Application.Commands.Command;
using CarExpo.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService _orderService)
        {
            this._orderService = _orderService;
        }

        [HttpPost("OrderCar")]
        public async Task<IActionResult> OrderCarAsync(OrderCommand orderCommand)
        {
            return Ok(orderCommand);
        }
    }
}
