using CarExpo.Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string NationalCode { get; set; }

        public string Email { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();



    }
}
