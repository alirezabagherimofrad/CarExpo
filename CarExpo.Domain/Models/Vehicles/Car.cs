using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Vehicles
{
    public class Car
    {
        public Car()
        {
            Id = Guid.NewGuid();
            CarImages = new List<CarImage>();
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string LicensePlate { get; set; } // پلاک خودرو 

        public string VIN { get; set; }  //مخفف => Vehicle Identification Number (VIN) 

        public string ManufactureYear { get; set; }

        public decimal Mileage { get; set; } // میزان کارکرد خودرو 

        public CarStatus? CarStatus { get; set; }

        public salestatus? Salestatus { get; set; }

        public ICollection<CarImage> CarImages { get; set; }

    }
    public enum CarStatus
    {
        LowUsage,
        HighUsage
    }
    public enum salestatus
    {
        Purchased,
        NotSold,
        Unavailable,
    }
}
