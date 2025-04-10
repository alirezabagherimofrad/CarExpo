using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.VehicleCommand
{
    public class FilterCarCommand
    {
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public string? Color { get; set; }

        public string? ManufactureYear { get; set; }

        public decimal? Mileage { get; set; }

        public CarStatus? CarStatus { get; set; }

        public salestatus? Salestatus { get; set; }

    }
}
