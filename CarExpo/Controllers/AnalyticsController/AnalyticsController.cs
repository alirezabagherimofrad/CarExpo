using CarExpo.Application.Commands.Command.IAnalyticsCommand;
using CarExpo.Application.Dto.IanalyticsDto;
using CarExpo.Application.Interfaces.IIAnalytics_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.IAnalyticsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _iAnalyticsService;

        public AnalyticsController(IAnalyticsService iAnalyticsService)
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

        [HttpGet("GetCarSalesCountByMonth")]
        public async Task<IActionResult> GetCarSalesCountByMonthAsync([FromQuery] AnalyticsCommand analyticsCommand)
        {
            var report = await _iAnalyticsService.GetCarSalesCountByMonthAsync(analyticsCommand.Year, analyticsCommand.Month);
            return Ok(report);
        }

        [HttpGet("GetListOfCarsSold")]
        public async Task<IActionResult> GetListOfCarsSoldAsync()
        {
            var report = await _iAnalyticsService.GetListOfCarsSold();
            return Ok(report);
        }

        [HttpGet("GetListOfNotSold")]
        public async Task<IActionResult> GetListOfNotSoldAsync()
        {
            var report = await _iAnalyticsService.GetListOfNotSold();
            return Ok(report);
        }

        [HttpGet("GetListOfPendingReviewAsync")]
        public async Task<IActionResult> GetListOfPendingReviewAsync()
        {
            var report = await _iAnalyticsService.GetListOfPendingReview();
            return Ok(report);
        }
    }
}
