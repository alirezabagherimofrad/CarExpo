using CarExpo.Domain.Interfaces.CarRepositories;
using CarExpo.Domain.Interfaces.IGenericInterface;
using CarExpo.Domain.Interfaces.OrderRpository;
using CarExpo.Domain.Interfaces.PaymentInterface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Domain.Interfaces.UserRepository;
using CarExpo.Domain.Models.Orders;
using CarExpo.Domain.Models.Payment;
using CarExpo.Domain.Models.Users;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure.Context;
using CarExpo.Infrastructure.Repositories.Car_Repository;
using CarExpo.Infrastructure.Repositories.Order_Repository;
using CarExpo.Infrastructure.Repositories.Payment_Repository;
using CarExpo.Infrastructure.Repositories.User_Repository;
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
    private IOrderRepository? _orderRepository;
    public IOrderItemRepository? _orderItemRepository;
    public IPaymentRepository? _paymentRepository;
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

    public IOrderRepository OrderRepository
    {
        get
        {
            if (_orderRepository == null)
                _orderRepository = new OrderRepository(_context);

            return _orderRepository;
        }
    }

    public IOrderItemRepository OrderItemRepository
    {
        get
        {
            if (_orderItemRepository == null)
                _orderItemRepository = new OrderItemRepository(_context);
            return _orderItemRepository;
        }
    }

    public IPaymentRepository PaymentRepository
    {
        get
        {
            if (_paymentRepository == null)
                _paymentRepository = new PaymentRepository(_context);
            return _paymentRepository;
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

        if (typeof(T) == typeof(Order))
        {
            _orderRepository ??= new OrderRepository(_context);
            return (IGenericRepository<T>)_orderRepository;
        }

        if (typeof(T) == typeof(OrderItem))
        {
            _orderItemRepository ??= new OrderItemRepository(_context);
            return (IGenericRepository<T>)_orderItemRepository;
        }

        if (typeof(T) == typeof(Payment))
        {
            _paymentRepository ??= new PaymentRepository(_context);
            return (IGenericRepository<T>)_paymentRepository;
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


