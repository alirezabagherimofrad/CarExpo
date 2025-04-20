using CarExpo.Application.Interfaces.IIAnalytics_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.IAnalyticsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class IAnalyticsController : ControllerBase
    {
        private readonly IIAnalyticsService _iAnalyticsService;

        public IAnalyticsController(IIAnalyticsService iAnalyticsService)
        {
            _iAnalyticsService = iAnalyticsService;
        }

        [HttpGet("GetTopCustomerReport")]
        public async Task<IActionResult> GetTopCustomersReportAsync()
        {
            var report = await _iAnalyticsService.GetTopCustomerAsync();
            return Ok(report);
        }

        [HttpGet("GetMostSoldCarBrandReport")]
        public async Task<IActionResult> GetMostSoldBrandAsync()
        {
            var report = await _iAnalyticsService.GetMostSoldBrandAsync();
            return Ok(report);
        }

        [HttpGet("GetMostSoldCarModelReport")]
        public async Task<IActionResult> GetTopCarModelAsync()
        {
            var report = await _iAnalyticsService.GetTopCarModel();
            return Ok(report);
        }
        [HttpGet("GetAscendingCarList")]
        public async Task<IActionResult> GetAscendingCarListAsync()
        {
            var report = await _iAnalyticsService.GetAscendingCarListAsync();
            return Ok(report);
        }
        [HttpGet("GetDescendingCarList")]
        public async Task<IActionResult> GetDescendingCarListAsync()
        {
            var report = await _iAnalyticsService.GetDescendingCarListAsync();
            return Ok(report);
        }
    }
}
