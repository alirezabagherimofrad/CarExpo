using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Car
{
    public class Car
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string LicensePlate { get; set; }

        public string VIN { get; set; }  //مخفف => Vehicle Identification Number (VIN) 

        public string ManufactureYear { get; set; }

        public decimal Mileage { get; set; } // میزان کارکرد خودرو 

        public string CarStatus { get; set; }
    }
}
