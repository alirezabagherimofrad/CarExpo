
using CarExpo.Domain.Interfaces;
using CarExpo.Domain.Models.Users;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure;
using CarExpo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _context;
    private readonly Dictionary<Type, object> _repositories = new();
    private IUserRepository? _userRepository;
    private IVehicleRepository? _vehicleRepository;
    private ICarImageRepository? _carImageRepository;
    public UnitOfWork(DataBaseContext context)
    {
        _context = context;
    }

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
                _userRepository = new UserRepository(_context);

            return _userRepository;
        }
    }

    public IVehicleRepository VehicleRepository
    {
        get
        {
            if (_vehicleRepository == null)
                _vehicleRepository = new VehicleRepository(_context);

            return _vehicleRepository;
        }
    }

    public ICarImageRepository CarImageRepository
    {
        get
        {
            if (_carImageRepository == null)
                _carImageRepository = new CarImageRepository(_context);

            return _carImageRepository;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IGenericRepository<T> Repository<T>() where T : class
    {
        if (typeof(T) == typeof(User))
        {
            _userRepository ??= new UserRepository(_context);
            return (IGenericRepository<T>)_userRepository;
        }

        if (typeof(T) == typeof(Car))
        {
            _vehicleRepository ??= new VehicleRepository(_context);
            return (IGenericRepository<T>)_vehicleRepository;
        }

        if (typeof(T) == typeof(CarImage))
        {
            _carImageRepository ??= new CarImageRepository(_context);
            return (IGenericRepository<T>)_carImageRepository;
        }

        if (!_repositories.ContainsKey(typeof(T)))
        {
            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);
        }
        return (IGenericRepository<T>)_repositories[typeof(T)];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}


