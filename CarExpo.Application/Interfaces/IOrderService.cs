using CarExpo.Application.Commands.Command;
using CarExpo.Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order?> OrederCar(OrderCommand orderCommand);
    }
}
