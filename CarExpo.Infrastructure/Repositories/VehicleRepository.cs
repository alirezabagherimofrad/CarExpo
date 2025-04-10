using CarExpo.Domain.Interfaces;
using CarExpo.Domain.Models.Brands;
using CarExpo.Domain.Models.Users;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Repositories
{
    public class VehicleRepository : GenericRepository<Car>, IVehicleRepository
    {
        public VehicleRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            _context.Cars.Add(car);

            await _context.SaveChangesAsync();

            return car;
        }
        public async Task<bool> IsExistAsync(Expression<Func<Car, bool>> predicate)
        {
            return await _context.Set<Car>().AnyAsync(predicate);
        }

        public async Task<Car> EditCarInfoAsyncc(Car car)
        {
            _dbSet.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<List<Car>> FilterCarsAsync(string? Brand, string? Model, string? Color, string? ManufactureYear, decimal? Mileage, CarStatus? CarStatus)
        {
            var search = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(Brand))
                search = search.Where(c => c.Brand.Title == Brand);

            if (!string.IsNullOrEmpty(Model))
                search = search.Where(c => c.Model == Model);

            if (!string.IsNullOrEmpty(Color))
                search = search.Where(c => c.Color == Color);

            if (!string.IsNullOrEmpty(ManufactureYear))
                search = search.Where(c => c.Model == Model);

            if (Mileage.HasValue)
                search = search.Where(c => c.Mileage == Mileage);

            if (CarStatus.HasValue)
                search = search.Where(c => c.CarStatus == CarStatus);

            return await search.ToListAsync();
        }

        public async Task<Brand> GetByBrand(Guid Id)
        {
            var brand = await _context.Set<Brand>().FirstOrDefaultAsync(b => b.Id == Id);
            if (brand == null)
            {
                throw new Exception("Brand not found.");
            }
            return brand;
        }

        public async Task AddBrandAsync(Brand brand)
        {
            _context.Set<Brand>().Add(brand);
            await _context.SaveChangesAsync();
        }
    }
}
