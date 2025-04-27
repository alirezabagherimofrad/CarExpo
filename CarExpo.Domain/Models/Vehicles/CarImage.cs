using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Vehicles
{
    public class CarImage
    {
        public CarImage()
        {

        }
        public CarImage(string name, string path, Guid carId, Guid userid)
        {
            Id = Guid.NewGuid();
            Name = name;
            Path = path;
            CarId = carId;
            UserId = userid;
        }

        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public Guid CarId { get; private set; }

        public string Name { get; private set; }

        public string Path { get; private set; }

        public Car Car { get; private set; }

    }
}
