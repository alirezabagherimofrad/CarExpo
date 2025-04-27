using CarExpo.Domain.Interfaces.CarRepositories;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Repositories.Car_Repository
{
    public class CarImageRepository : GenericRepository<CarImage>, ICarImageRepository
    {
        public CarImageRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
