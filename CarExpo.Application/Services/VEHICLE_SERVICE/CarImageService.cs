using AutoMapper;
using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Application.Interfaces;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.VEHICLE_SERVICE
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
        public async Task UploadCarImage(IFormFile file, UploadCarImageCommand carImageCommand)
        {
            if (file == null || file.Length <= 0)
                throw new Exception("فایل معتبر نیست");

            var car = await _unitOfWork.VehicleRepository.GetByIdAsync(carImageCommand.CarId);

            if (car == null)
            {

                throw new Exception("ماشینی با این آیدی پیدا نشد");
            }
            var directoryPath = "C:\\Users\\LENOVO\\Documents\\carimage";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var filePath = Path.Combine(directoryPath, file.FileName);

            var carImage = new CarImage(file.FileName, filePath, carImageCommand.CarId);

            using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            await file.CopyToAsync(stream);

            await _unitOfWork.CarImageRepository.AddAsync(carImage);
        }


        public async Task<FileContentResult> DownloadCarImageAsync(DownloadCarImageCommand carDownloadImageCommand)
        {
            var file = await _unitOfWork.CarImageRepository.DownloadCarImageAsync(carDownloadImageCommand.FileId);

            if (file == null || file.Id != carDownloadImageCommand.FileId)
                throw new Exception(" آیدی فایل یافت نشد");

            var fileBytes = await File.ReadAllBytesAsync(file.Path);

            return new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = file.Name
            };
        }

    }
}
