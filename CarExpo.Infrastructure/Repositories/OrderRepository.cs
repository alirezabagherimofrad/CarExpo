using CarExpo.Domain.Interfaces;
using CarExpo.Domain.Models.Orders;
using CarExpo.Domain.Models.Users;
using CarExpo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
