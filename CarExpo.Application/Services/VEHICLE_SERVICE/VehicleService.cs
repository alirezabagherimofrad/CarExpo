using AutoMapper;
using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Application.Interfaces;
using CarExpo.Domain.Models.Brands;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.VEHICLE_SERVICE
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VehicleService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            this._unitOfWork = _unitOfWork;
            this._mapper = _mapper;
        }

        public async Task<Car> AddCar(AddCarCommand addCarCommand)
        {
            addCarCommand.Validate();

            var carExsist = await _unitOfWork.VehicleRepository.IsExistAsync(c => c.VIN == addCarCommand.VIN);

            if (carExsist)
                throw new Exception("این خودرو قبلا ثبت شده هست");

            var brand = await _unitOfWork.VehicleRepository.GetByBrand(addCarCommand.BrandId);

            //if (brand == null)
            //    brand = new Brand { Title = addCarCommand.BrandId };
            //await _unitOfWork.VehicleRepository.AddBrandAsync(brand);

            var car = _mapper.Map<Car>(addCarCommand);

            car.BrandId = brand.Id;

            if (car.UserId != addCarCommand.UserId)
                throw new Exception("آیدی مشکل دارد");

            await _unitOfWork.VehicleRepository.AddCarAsync(car);

            return car;
        }

        public async Task<Brand> BrandAsync(Brand brand)
        {
            var result = await _unitOfWork.VehicleRepository.GetByBrand(brand.Id);

            if (result == null)
                throw new Exception("نتیجه خالی هست");

            return result;
        }

        public async Task<List<Car>> FilterCars(FilterCarCommand carSearchCommand)
        {
            var result = await _unitOfWork.VehicleRepository.FilterCarsAsync(
            carSearchCommand.Brand,
            carSearchCommand.Model,
            carSearchCommand.Color,
            carSearchCommand.ManufactureYear,
            carSearchCommand.Mileage,
            carSearchCommand.CarStatus);

            return result;
        }

        public async Task<Car> UpdateInfoCar(EditCarInfoCommand editCarInfoCommand)
        {
            editCarInfoCommand.Validate();

            var car = _mapper.Map<Car>(editCarInfoCommand);

            if (car.Id != editCarInfoCommand.Id)
            {
                throw new Exception("آیدی ماشین درست نمی باشد");
            }

            if (car.Color != null && car.Color != editCarInfoCommand.Color)
                car.Color = editCarInfoCommand.Color;

            //if (car.Brand != null && car.Brand.Title != editCarInfoCommand.Brand)
            //    car.Brand = editCarInfoCommand.Brand.Title;

            if (car.Model != null && car.Model != editCarInfoCommand.Model)
                car.Model = editCarInfoCommand.Model;

            if (car.ManufactureYear != null && car.ManufactureYear != editCarInfoCommand.ManufactureYear)
                car.ManufactureYear = editCarInfoCommand.ManufactureYear;

            if (car.LicensePlate != null && car.LicensePlate != editCarInfoCommand.LicensePlate)
                car.LicensePlate = editCarInfoCommand.LicensePlate;

            if (car.Mileage != null && car.Mileage != editCarInfoCommand.Mileage)
                car.Mileage = editCarInfoCommand.Mileage;

            if (car.VIN != null && car.VIN != editCarInfoCommand.VIN)
                car.VIN = editCarInfoCommand.VIN;

            //if (car.CarStatus != null && car.CarStatus != editCarInfoCommand.CarStatus)
            //    car.CarStatus = editCarInfoCommand.CarStatus;

            await _unitOfWork.VehicleRepository.EditCarInfoAsyncc(car);

            return car;
        }
    }
}
