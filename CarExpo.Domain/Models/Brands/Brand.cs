using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Brands
{
    public class Brand
    {
        public Guid Id { get; set; } 

        public string Title { get; set; }
    }
}
