using CarExpo.Domain.Interfaces.IGenericInterface;
using CarExpo.Domain.Models.Brands;
using CarExpo.Domain.Models.Users;
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces.CarRepositories
{
    public interface IVehicleRepository : IGenericRepository<Car>
    {

        Task<bool> IsExistAsync(Expression<Func<Car, bool>> predicate);

        Task<Car> EditCarInfoAsyncc(Car car);

        Task<List<Car>> FilterCarsAsync(string? Brand, string? Model, string? Color, int? ManufactureYear, decimal? Mileage, CarStatus? CarStatus);

        Task<Brand> GetByBrand(Guid Id);
        Task AddBrandAsync(Brand brand);


    }
}
