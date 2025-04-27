using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Orders
{
    public class OrderItem
    {
        public OrderItem()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

        public Guid OrderId { get; private set; }

        public Guid CarId { get; private set; }

        public int? TotalPrice { get; private set; }

        public Order? Order { get; private set; }

        public void orderid(Guid id)
        {
            OrderId = id;
        }
        public void carid(Guid id)
        {
            CarId = id;
        }
        public void price(int? totalprice)
        {
            TotalPrice = totalprice;
        }
    }
}
