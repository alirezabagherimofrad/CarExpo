
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
            Id = Guid.NewGuid();
            OrderTime = DateTime.Now;
        }

        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal TotalPrice { get; set; }

        public DateTime OrderTime { get; set; }

        public bool IsPaid { get; set; }
    }
}
