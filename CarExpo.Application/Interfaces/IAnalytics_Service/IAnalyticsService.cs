using CarExpo.Application.Dto.CarDto;
using CarExpo.Application.Dto.IanalyticsDto;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.IIAnalytics_Service
{
    public interface IAnalyticsService
    {
        Task<List<CarModelSalesDto>> GetCarSalesCountByMonthAsync(int year, int month);
        Task<TopCustomerDto> GetTopCustomerAsync();
        Task<TopBrandDto> GetMostSoldBrandAsync();
        Task<TopCarModelDto> GetTopCarModel();
        Task<CarListDto> GetAscendingCarListAsync();
        Task<CarListDto> GetDescendingCarListAsync();
        Task<List<CarListDto>> GetListOfCarsSold();
        Task<List<CarListDto>> GetListOfNotSold();
        Task<List<CarListDto>> GetListOfPendingReview();
    }
}
