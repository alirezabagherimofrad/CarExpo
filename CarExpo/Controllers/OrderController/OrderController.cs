using CarExpo.Application.Commands.Command.OrserCommand;
using CarExpo.Application.Interfaces.Order_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.OrderController
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
            var order = await _orderService.OrederCar(orderCommand);

            return Ok(order);
        }
    }
}
