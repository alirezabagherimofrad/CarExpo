using AutoMapper;
using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Application.Interfaces.Car_Interface;
using CarExpo.Application.Interfaces.Email_Interface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Domain.Models;
using CarExpo.Domain.Models.Brands;
using CarExpo.Domain.Models.Users;
using CarExpo.Domain.Models.Vehicles;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailNotificationService _emailNotificationService;
        public VehicleService(IUnitOfWork _unitOfWork, IMapper _mapper, IEmailNotificationService emailNotificationService)
        {
            this._unitOfWork = _unitOfWork;
            this._mapper = _mapper;
            _emailNotificationService = emailNotificationService;
        }

        public async Task<Car> AddCar(AddCarCommand addCarCommand)
        {
            if (addCarCommand == null)
                throw new Exception("درخواست ثبت خودرو معتبر نیست.");

            addCarCommand.Validate();

            var carExsist = await _unitOfWork.VehicleRepository.IsExistAsync(c =>
                c.VIN == addCarCommand.VIN && c.LicensePlate == addCarCommand.LicensePlate);

            if (carExsist)
                throw new Exception("این خودرو قبلاً ثبت شده است.");

            var brand = await _unitOfWork.VehicleRepository.GetByBrand(addCarCommand.BrandId);

            if (brand == null)
                throw new Exception("برند انتخاب‌شده وجود ندارد.");

            var car = _mapper.Map<Car>(addCarCommand);


            if (car.UserId != addCarCommand.UserId)
                throw new Exception("مشکل در آیدی کاربر.");

            var user = await _unitOfWork.UserRepository.GetByIdAsync(addCarCommand.UserId);

            if (user == null)
                throw new Exception("کاربری با این شناسه یافت نشد.");

            var subjectForOwner = "سلام از CarExpo";
            var bodyForOwner = $"سلام {(user.UserName ?? "کاربر عزیز")}، ثبت اطلاعات خودروی شما با موفقیت انجام شد";

            if (!string.IsNullOrEmpty(user.Email))
            {
                await _emailNotificationService.SendEmail(user.Email, subjectForOwner, bodyForOwner);

                var notif = new Notification(user.Id, subjectForOwner, bodyForOwner);

                await _unitOfWork.NotificationRepository.AddAsync(notif);
            }

            //var allUsers = await _unitOfWork.UserRepository.GetAllAsync();

            //var subjectForOthers = "سلامی از CarExpo خوبی؟";

            //var bodyForOthers = "سلام سلطان حالت چطوره امروز یه ماشین جدید اومده بیا ببین یه وقت شاید جریحه دار شدیا ";

            //foreach (var u in allUsers)
            //{
            //    if (u.Email != user.Email && !string.IsNullOrEmpty(u.Email))
            //    {
            //        await _emailNotificationService.SendEmail(u.Email, subjectForOthers, bodyForOthers);

            //        var Notif = new Notification(user.Id, subjectForOthers, bodyForOthers);

            //        await _unitOfWork.NotificationRepository.AddAsync(Notif);
            //    }
            //}
            await _unitOfWork.VehicleRepository.AddAsync(car);

            await _unitOfWork.SaveChangesAsync();

            return car;
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

            var car = await _unitOfWork.VehicleRepository.GetByIdAsync(editCarInfoCommand.CarId);

            if (car.Id != editCarInfoCommand.CarId)
            {
                throw new Exception("آیدی ماشین درست نمی باشد");
            }

            car.UpdateCar(
               editCarInfoCommand.Color,
                editCarInfoCommand.Model,
                editCarInfoCommand.ManufactureYear,
                editCarInfoCommand.LicensePlate,
                editCarInfoCommand.Mileage,
                editCarInfoCommand.VIN,
                editCarInfoCommand.TotalPrice,
                editCarInfoCommand.CarStatus,
                editCarInfoCommand.SaleStatus
                );

            await _unitOfWork.VehicleRepository.UpdateAsync(car);

            await _unitOfWork.SaveChangesAsync();

            return car;
        }
    }
}
