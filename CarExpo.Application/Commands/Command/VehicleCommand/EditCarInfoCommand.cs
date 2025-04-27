using CarExpo.Application.Commands.CommandValidator;
using CarExpo.Application.Commands.CommandValidator.VehicleCommandValidator;
using CarExpo.Domain.Models.Vehicles;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Commands.Command.VehicleCommand
{
    public class EditCarInfoCommand
    {

        public Guid CarId { get; set; }

        public string? Model { get; set; }

        public string? Color { get; set; }

        public string? LicensePlate { get; set; }

        public string? VIN { get; set; }

        public int? ManufactureYear { get; set; }

        public int? Mileage { get; set; }

        public CarStatus? CarStatus { get; set; }

        public salestatus? SaleStatus { get; set; }

        public int? TotalPrice { get; set; }

        //public void Validate()
        //{
        //    if (!new EditCarInfoCommandValidator().Validate(this).IsValid)
        //    {
        //        var error = new EditCarInfoCommandValidator().Validate(this).Errors.FirstOrDefault();
        //        throw new Exception($"{error.ErrorMessage}");
        //    }
        //}
    }
}
