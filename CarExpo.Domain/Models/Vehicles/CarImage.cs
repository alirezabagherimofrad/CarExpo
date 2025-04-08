using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Vehicles
{
    public class CarImage
    {
        public CarImage(string name, string path,Guid carId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Path = path;
            CarId = carId;
        }

        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public Car Car { get; set; }

    }
}
