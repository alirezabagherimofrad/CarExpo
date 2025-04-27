
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Orders
{
    public class Order
    {
        public Order()
        {
            
        }
        public Order(Guid carid)
        {
            Id = Guid.NewGuid();
            OrderTime = DateTime.Now;
            CarId=carid;
        }

        public Guid Id { get; private set; }

        public Guid CarId { get; private set; }

        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

        public int? TotalPrice { get; private set; }

        public DateTime OrderTime { get; private set; }

        public bool IsPaid { get; private set; }

        public void paid(bool ispaid)
        {
            IsPaid=ispaid;
        }

        public void price(Car car)
        {
            TotalPrice=car.TotalPrice;
        }
    }
}
