using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Domain.Models.Vehicles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.Car_Interface
{
    public interface ICarImageService
    {
        Task UploadCarImage(IFormFile file, UploadCarImageCommand UploadCarImageCommand);

        Task<FileContentResult> DownloadCarImageAsync(DownloadCarImageCommand carDownloadImageCommand);
        Task<CarImage?> DeleteCarImage(RemoveCarCommand removeCarCommand);
    }
}
