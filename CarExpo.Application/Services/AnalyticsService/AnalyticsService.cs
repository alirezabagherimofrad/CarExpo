using CarExpo.Application.Dto.CarDto;
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
    public class AnalyticsService : IAnalyticsService
    {
        private readonly DataBaseContext _dataBaseContext;

        public AnalyticsService(DataBaseContext dataBaseContext)
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

        public async Task<List<CarModelSalesDto>> GetCarSalesCountByMonthAsync(int year, int month)
        {
            var result = await (from p in _dataBaseContext.Payments
                                join c in _dataBaseContext.Cars on p.CarId equals c.Id
                                where p.TimeOfpayment.Year == year && p.TimeOfpayment.Month == month && c.Salestatus == salestatus.Purchased
                                group c by c.Model into g
                                select new CarModelSalesDto
                                {
                                    ModelName = g.Key,
                                    Count = g.Count(),
                                }).OrderByDescending(x => x.Count).ToListAsync();

            return result;
        }

        public async Task<List<CarListDto>> GetListOfCarsSold()
        {
            var result = await _dataBaseContext.Cars.Where(c => c.Salestatus == salestatus.Purchased).Select(c => new CarListDto
            {
                Id = c.Id,
                ModelName = c.Model,
                TotalPrice = c.TotalPrice,
            }).ToListAsync();

            return result;
        }

        public async Task<List<CarListDto>> GetListOfNotSold()
        {
            var result = await _dataBaseContext.Cars.Where(c => c.Salestatus == salestatus.NotSold).Select(c => new CarListDto
            {
                Id = c.Id,
                ModelName = c.Model,
                TotalPrice = c.TotalPrice,
            }).ToListAsync();

            return result;
        }

        public async Task<List<CarListDto>> GetListOfPendingReview()
        {
            var result = await _dataBaseContext.Cars.Where(c => c.Salestatus == salestatus.pendingreview).Select(c => new CarListDto
            {
                Id = c.Id,
                ModelName = c.Model,
                TotalPrice = c.TotalPrice
            }).ToListAsync();

            return result;
        }
    }
}
