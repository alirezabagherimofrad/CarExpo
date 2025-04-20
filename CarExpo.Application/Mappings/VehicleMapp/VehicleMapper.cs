using AutoMapper;
using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Mappings.VehicleMapp
{
    public class VehicleMapper : Profile
    {
        public VehicleMapper()
        {
            CreateMap<Car, AddCarCommand>().ReverseMap();

            CreateMap<Car, EditCarInfoCommand>().ReverseMap();

            CreateMap<CarImage, UploadCarImageCommand>().ReverseMap();
        }
    }
}
