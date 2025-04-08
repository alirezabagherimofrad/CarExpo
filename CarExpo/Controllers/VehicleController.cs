using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers
{
    [ApiController]
    [Route("api/Vehicle/[Controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService _vehicleService)
        {
            this._vehicleService = _vehicleService;
        }

        [HttpPost("AddCarInformation")]
        public async Task<IActionResult> AddCarInformationAsync(AddCarCommand addCarCommand)
        {
            addCarCommand.Validate();

            var result = await _vehicleService.AddCar(addCarCommand);

            return Ok(result);
        }
        [HttpPut("EditCarInfo")]
        public async Task<IActionResult> EditCarInfo(EditCarInfoCommand editCarInfoCommand)
        {
            editCarInfoCommand.Validate();

            var result = await _vehicleService.UpdateInfoCar(editCarInfoCommand);

            return Ok(result);
        }

        [HttpGet("SearchCar")]
        public async Task<IActionResult> SearchCarAsync([FromQuery] CarSearchCommand carSearchCommand)
        {
            var Car = await _vehicleService.FilterCars(carSearchCommand);

            if (Car == null)
                return BadRequest("هیچ ماشینی با این مشخصات پیدا نشد");

            return Ok(Car);
        }
    }
}
