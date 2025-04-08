using AutoMapper;
using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Application.Interfaces;
using CarExpo.Domain.Models.CarBrands;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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

            Car car; // تعریف فقط، نه مقداردهی

            var normalizedBrand = addCarCommand.Brand.ToLower();

            switch (normalizedBrand)
            {
                case "bahmanmotor":
                    car = _mapper.Map<BahmanMotor>(addCarCommand);
                    break;

                case "brilliance":
                    car = _mapper.Map<Brilliance>(addCarCommand);
                    break;

                case "chery":
                    car = _mapper.Map<Chery>(addCarCommand); // اینجا قبلاً اشتباهی JAC بود!
                    break;

                case "hyundai":
                    car = _mapper.Map<Hyundai>(addCarCommand);
                    break;

                case "jac":
                    car = _mapper.Map<JAC>(addCarCommand);
                    break;

                case "kia":
                    car = _mapper.Map<Kia>(addCarCommand);
                    break;

                case "lifan":
                    car = _mapper.Map<Lifan>(addCarCommand);
                    break;

                case "modirankhodro":
                    car = _mapper.Map<ModiranKhodro>(addCarCommand);
                    break;

                case "parskhodro":
                    car = _mapper.Map<ParsKhodro>(addCarCommand);
                    break;

                case "peugeot":
                    car = _mapper.Map<Peugeot>(addCarCommand);
                    break;

                case "renault":
                    car = _mapper.Map<Renault>(addCarCommand);
                    break;

                case "saipa":
                    car = _mapper.Map<Saipa>(addCarCommand);
                    break;

                default:
                    car = _mapper.Map<Car>(addCarCommand);
                    car.Brand = addCarCommand.Brand;
                    break;
            }

            if (car.UserId != addCarCommand.UserId)
                throw new Exception("آیدی مشکل دارد");

            await _unitOfWork.VehicleRepository.AddCarAsync(car);

            return car;
        }




        public async Task<List<Car>> FilterCars(CarSearchCommand carSearchCommand)
        {
            var result = await _unitOfWork.VehicleRepository.FilterCarsAsync(carSearchCommand.Brand,
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

            if (car.Brand != null && car.Brand != editCarInfoCommand.Brand)
                car.Brand = editCarInfoCommand.Brand;

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
