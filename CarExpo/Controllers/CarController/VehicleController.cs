﻿using CarExpo.Application.Commands.Command.VehicleCommand;
using CarExpo.Application.Interfaces.Car_Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.CarController
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

            var result = await _vehicleService.AddCar(addCarCommand);

            return Ok(result);
        }

        [HttpPut("EditCarInfo")]
        public async Task<IActionResult> EditCarInfo(EditCarInfoCommand editCarInfoCommand)
        {
            var result = await _vehicleService.UpdateInfoCar(editCarInfoCommand);

            return Ok(result);
        }

        [HttpGet("FilterCar")]
        public async Task<IActionResult> FilterCarAsync([FromQuery] FilterCarCommand filterCarCommand)
        {
            var Car = await _vehicleService.FilterCars(filterCarCommand);

            if (Car == null)
                return BadRequest("هیچ ماشینی با این مشخصات پیدا نشد");

            return Ok(Car);
        }
    }
}
