﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Orders
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid CarId { get; set; }

        public decimal? TotalPrice { get; set; }

        public Order? Order { get; set; }


    }
}
