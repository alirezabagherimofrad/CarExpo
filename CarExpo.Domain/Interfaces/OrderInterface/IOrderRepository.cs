using CarExpo.Domain.Interfaces.IGenericInterface;
using CarExpo.Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces.OrderRpository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {

    }

}
