using CarExpo.Domain.Models.Orders;
using CarExpo.Domain.Models.Users;
using CarExpo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
