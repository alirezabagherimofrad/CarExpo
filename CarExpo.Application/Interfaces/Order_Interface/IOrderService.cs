using CarExpo.Application.Commands.Command.OrserCommand;
using CarExpo.Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.Order_Interface
{
    public interface IOrderService
    {
        Task<Order?> OrederCar(OrderCommand orderCommand);
    }
}
