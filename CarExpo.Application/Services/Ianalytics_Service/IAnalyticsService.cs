using CarExpo.Application.Dto.IanalyticsDto;
using CarExpo.Application.Interfaces.IIAnalytics_Service;
using CarExpo.Domain.Models.Brands;
using CarExpo.Domain.Models.Users;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.IAnalytics_Service
{
    public class IAnalyticsService : IIAnalyticsService
    {
        private readonly DataBaseContext _dataBaseContext;

        public IAnalyticsService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }


        public async Task<TopCustomerDto> GetTopCustomerAsync()
        {
            var user = await _dataBaseContext.Users.OrderByDescending(u => u.LoyaltyPoints).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("همچین کاربری وجود ندارد");

            var topCustomerDto = new TopCustomerDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Id = user.Id,
                Points = user.LoyaltyPoints,
            };
            return topCustomerDto;
        }

        public async Task<TopBrandDto> GetMostSoldBrandAsync()
        {
            var result = await _dataBaseContext.Cars.Where(c => c.Salestatus == salestatus.Purchased).Include(c => c.Brand).GroupBy(c => c.Brand.Title).Select(g => new
            {
                BrandName = g.Key,
                Count = g.Count()
            }).OrderByDescending(c => c.Count).FirstOrDefaultAsync();

            if (result == null)
                throw new Exception("هنوز ماشینی ثبت نشده");

            var dto = new TopBrandDto
            {
                BrandName = result.BrandName,
                SoldCount = result.Count,
            };

            return dto;
        }

        public async Task<TopCarModelDto> GetTopCarModel()
        {
            var result = await _dataBaseContext.Cars.Where(c => c.Salestatus == salestatus.Purchased).GroupBy(c => c.Model).Select(g => new
            {
                ModelName = g.Key,
                Count = g.Count()
            }).OrderByDescending(c => c.Count).FirstOrDefaultAsync();

            if (result == null) throw new Exception("همچین مدل ماشینی وجود ندارد");

            var ModelDto = new TopCarModelDto
            {
                ModelName = result.ModelName,
                SoldCount = result.Count,
            };
            return ModelDto;
        }

        public async Task<CarListDto> GetAscendingCarListAsync()
        {
            var result = await _dataBaseContext.Cars.Where(c => c.TotalPrice != null && c.Salestatus != salestatus.Unavailable && c.Salestatus != salestatus.Purchased).Include(c => c.Brand).OrderBy(c => c.TotalPrice).FirstOrDefaultAsync();

            if (result == null) throw new Exception("ماشینی وجود ندارد");
            var dto = new CarListDto
            {
                Id = result.Id,
                ModelName = result.Model,
                TotalPrice = result.TotalPrice,
            };
            return dto;
        }
        public async Task<CarListDto> GetDescendingCarListAsync()
        {
            var result = await _dataBaseContext.Cars.Where(c => c.TotalPrice != null && c.Salestatus != salestatus.Unavailable && c.Salestatus != salestatus.Purchased).Include(c => c.Brand).OrderByDescending(c => c.TotalPrice).FirstOrDefaultAsync();

            if (result == null) throw new Exception("ماشینی وجود ندارد");
            var dto = new CarListDto
            {
                Id = result.Id,
                ModelName = result.Model,
                TotalPrice = result.TotalPrice,
            };
            return dto;
        }
    }
}
