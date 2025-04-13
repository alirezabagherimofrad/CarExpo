using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Application.Dto;
using CarExpo.Application.Interfaces.Car_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.CarController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public CarImageController(ICarImageService _carImageService)
        {
            this._carImageService = _carImageService;
        }

        [HttpPost("UploadCarImage")]
        public async Task<IActionResult> UploadCarImageAsync([FromForm] CarImageDto carImageDto)
        {
            if (carImageDto.File == null || carImageDto.File.Length < 0)
                return BadRequest("فایل معتبر ارسال نشده");

            var command = new UploadCarImageCommand { CarId = carImageDto.CarId };

            await _carImageService.UploadCarImage(carImageDto.File, command);

            return Ok("تصویر با موفقیت آپلود شد");
        }

        [HttpPost("DownloadCarImage")]
        public async Task<IActionResult> DownloadCarImageAsync([FromBody] DownloadCarImageCommand carDownloadImageCommand)
        {
            var result = await _carImageService.DownloadCarImageAsync(carDownloadImageCommand);

            return Ok(result);
        }
    }
}
