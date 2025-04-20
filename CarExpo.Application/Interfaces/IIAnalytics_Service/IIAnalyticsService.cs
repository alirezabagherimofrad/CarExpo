using CarExpo.Application.Dto.IanalyticsDto;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.IIAnalytics_Service
{
    public interface IIAnalyticsService
    {
        Task<TopCustomerDto> GetTopCustomerAsync();
        Task<TopBrandDto> GetMostSoldBrandAsync();
        Task<TopCarModelDto> GetTopCarModel();
        Task<CarListDto> GetAscendingCarListAsync();
        Task<CarListDto> GetDescendingCarListAsync();
    }
}
