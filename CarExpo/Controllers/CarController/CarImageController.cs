using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Application.Dto.CarDto;
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
        public async Task<IActionResult> UploadCarImageAsync([FromForm] UploadCarImageCommand UploadCarImageCommand)
        {
            if (UploadCarImageCommand.File == null || UploadCarImageCommand.File.Length < 0)
                return BadRequest("فایل معتبر ارسال نشده");

            await _carImageService.UploadCarImage(UploadCarImageCommand.File, UploadCarImageCommand);

            return Ok("تصویر با موفقیت آپلود شد");
        }

        [HttpGet("DownloadCarImage")]
        public async Task<IActionResult> DownloadCarImageAsync([FromQuery] DownloadCarImageCommand carDownloadImageCommand)
        {
            var result = await _carImageService.DownloadCarImageAsync(carDownloadImageCommand);

            return result;
        }

        [HttpDelete("DeleteCarImage")]
        public async Task<IActionResult> DeleteCarImageAsync(RemoveCarCommand removeCarCommand)
        {
            var result = await _carImageService.DeleteCarImage(removeCarCommand);

            return Ok(result);
        }
    }
}
