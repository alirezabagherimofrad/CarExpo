using AutoMapper;
using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Domain.Models.CarBrands;
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Mappings
{
    public class VehicleMapper : Profile
    {
        public VehicleMapper()
        {
            CreateMap<Car, AddCarCommand>().ReverseMap();

            CreateMap<Car, EditCarInfoCommand>().ReverseMap();

            CreateMap<CarImage, UploadCarImageCommand>().ReverseMap();


            CreateMap<AddCarCommand, BahmanMotor>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, Brilliance>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, Chery>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, Hyundai>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, JAC>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, KermanMotor>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, Kia>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, Lifan>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, ModiranKhodro>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, ParsKhodro>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, Peugeot>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, Renault>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();

            CreateMap<AddCarCommand, Saipa>()
                .IncludeBase<AddCarCommand, Car>()
                .ReverseMap();



        }
    }
}
