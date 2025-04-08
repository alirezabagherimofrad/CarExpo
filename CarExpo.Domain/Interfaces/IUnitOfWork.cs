using CarExpo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;
    IUserRepository UserRepository { get; }
    IVehicleRepository VehicleRepository { get; }
    ICarImageRepository CarImageRepository { get; }
    Task<int> SaveChangesAsync();
}

