using CarExpo.Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces.OrderRpository
{
    public interface IOrderItemRepository
    {
        Task AddItemAsync(OrderItem orderItem);
    }
}
