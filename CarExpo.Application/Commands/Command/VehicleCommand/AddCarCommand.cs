
using CarExpo.Application.Commands.CommandValidator.VehicleCommandValidator;
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.VehicleCommand
{
    public class AddCarCommand
    {
        public Guid UserId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string LicensePlate { get; set; }

        public string VIN { get; set; }

        public string ManufactureYear { get; set; }

        public decimal Mileage { get; set; }

        public CarStatus? CarStatus { get; set; }

        public salestatus? salestatus { get; set; }

        public void Validate()
        {
            if (!new AddCarCommandValidator().Validate(this).IsValid)
            {
                var error = new AddCarCommandValidator().Validate(this).Errors.FirstOrDefault();
                throw new Exception($"{error.ErrorMessage}");
            }
        }
    }
}
