using AutoMapper;
using CarExpo.Application.Commands.Command;
using CarExpo.Application.Interfaces;
using CarExpo.Domain.Models.Orders;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.Order_Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            this._unitOfWork = _unitOfWork;
            this._mapper = _mapper;
        }

        public async Task<Order?> OrederCar(OrderCommand orderCommand)
        {
            var result = await _unitOfWork.OrderRepository.GetByIdAsync(orderCommand.CarId);

            var car = _mapper.Map<Car>(orderCommand);

            if (car.Id != orderCommand.CarId || car.Id == null)
            {
                throw new Exception("ماشینی با این آیدی پیدا نشد");
            }

            if (car.Salestatus == salestatus.Purchased)
                throw new Exception("این ماشین با این آیدی فروخته شده");

            if (car.Salestatus == salestatus.Unavailable)
                throw new Exception("این ماشین با این آیدی در دسترس نیست ");

            var order = _mapper.Map<Order>(orderCommand);

            order.Id = Guid.NewGuid();

            order.OrderTime = DateTime.Now;

            order.IsPaid = false;

            car.Salestatus = salestatus.Purchased;

            await _unitOfWork.VehicleRepository.UpdateAsync(car);

            await _unitOfWork.OrderRepository.AddAsync(order);

            await _unitOfWork.SaveChangesAsync();

            return order;
        }
    }
}
