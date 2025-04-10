using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Domain.Models.Brands;
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<Car> AddCar(AddCarCommand addCarCommand);

        Task<Car> UpdateInfoCar(EditCarInfoCommand editCarInfoCommand);

        Task<List<Car>> FilterCars(FilterCarCommand carSearchCommand);

        Task<Brand> BrandAsync(Brand brand);

    }
}
