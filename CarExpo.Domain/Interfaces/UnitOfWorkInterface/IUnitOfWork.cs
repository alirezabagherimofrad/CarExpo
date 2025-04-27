using CarExpo.Domain.Interfaces.CarRepositories;
using CarExpo.Domain.Interfaces.IGenericInterface;
using CarExpo.Domain.Interfaces.OrderRpository;
using CarExpo.Domain.Interfaces.PaymentInterface;
using CarExpo.Domain.Interfaces.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces.UnitOfWorkInterface;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;
    IUserRepository UserRepository { get; }
    IVehicleRepository VehicleRepository { get; }
    ICarImageRepository CarImageRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderItemRepository OrderItemRepository { get; }
    IPaymentRepository PaymentRepository { get; }
    INotificationRepository NotificationRepository { get; }
    Task<int> SaveChangesAsync();
}

