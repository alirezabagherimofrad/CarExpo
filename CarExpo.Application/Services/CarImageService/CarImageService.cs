using AutoMapper;
using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Application.Interfaces.Car_Interface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Domain.Models.Vehicles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.CarImageService
{
    public class CarImageService : ICarImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarImageService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            this._unitOfWork = _unitOfWork;
            this._mapper = _mapper;
        }
        public async Task UploadCarImage(IFormFile file, UploadCarImageCommand UploadCarImageCommand)
        {
            if (file == null || file.Length <= 0)
                throw new Exception("فایل معتبر نیست");

            var car = await _unitOfWork.VehicleRepository.GetByIdAsync(UploadCarImageCommand.CarId);

            if (car == null)
                throw new Exception("ماشینی با این آیدی پیدا نشد");

            var user = await _unitOfWork.UserRepository.GetByIdAsync(UploadCarImageCommand.UserId);

            if (user == null) throw new Exception("این کاربر با این آیدی یافت نشد");

            var directoryPath = "C:\\Users\\LENOVO\\Documents\\carimage";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var filePath = Path.Combine(directoryPath, file.FileName);

            var carImage = new CarImage(file.FileName, filePath, UploadCarImageCommand.CarId, UploadCarImageCommand.UserId);

            using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            await file.CopyToAsync(stream);

            await _unitOfWork.CarImageRepository.AddAsync(carImage);
        }

        public async Task<FileContentResult> DownloadCarImageAsync(DownloadCarImageCommand carDownloadImageCommand)
        {
            var file = await _unitOfWork.CarImageRepository.GetByIdAsync(carDownloadImageCommand.FileId);

            if (file == null || file.Id != carDownloadImageCommand.FileId)
                throw new Exception(" آیدی فایل یافت نشد");

            var fileBytes = await File.ReadAllBytesAsync(file.Path);

            return new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = file.Name
            };
        }

        public async Task<CarImage?> DeleteCarImage(RemoveCarCommand removeCarCommand)
        {
            var file = await _unitOfWork.CarImageRepository.GetByIdAsync(removeCarCommand.ImageId);

            if (file == null)
                throw new Exception("این فایل با این آیدی وجد ندارد");

            await _unitOfWork.CarImageRepository.DeleteAsync(file);

            await _unitOfWork.SaveChangesAsync();

            return file;
        }
    }
}
