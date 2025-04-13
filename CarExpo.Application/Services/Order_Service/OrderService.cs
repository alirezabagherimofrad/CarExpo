using AutoMapper;
using CarExpo.Application.Commands.Command.OrserCommand;
using CarExpo.Application.Interfaces.Email_Interface;
using CarExpo.Application.Interfaces.Order_Interface;
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
        private readonly IEmailNotificationService _emailNotificationService;

        public OrderService(IUnitOfWork _unitOfWork, IMapper _mapper, IEmailNotificationService emailNotificationService)
        {
            this._unitOfWork = _unitOfWork;
            this._mapper = _mapper;
            _emailNotificationService = emailNotificationService;
        }

        public async Task<Order?> OrederCar(OrderCommand orderCommand)
        {
            var car = await _unitOfWork.VehicleRepository.GetByIdAsync(orderCommand.CarId);

            var user = await _unitOfWork.UserRepository.GetByIdAsync(orderCommand.UserId);

            if (user == null)
                throw new Exception("همچین کاربری وجود ندارد");

            if (user.Id != orderCommand.UserId)
                throw new Exception("همچین کاربری با این آیدی پیدا نشد");

            if (car == null)
                throw new Exception("ماشینی یا این آیدی یافت نشد ");

            if (car.Id != orderCommand.CarId)
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

            car.Salestatus = salestatus.pendingreview;

            order.TotalPrice = car.TotalPrice;

            //var orderitem = _mapper.Map<OrderItem>(orderCommand);

            //orderitem.Id = Guid.NewGuid();

            //orderitem.CarId = car.Id;

            //orderitem.OrderId = order.Id;

            //orderitem.TotalPrice = car.TotalPrice;

            var orderitem = new OrderItem();
            orderitem.Id = Guid.NewGuid();
            orderitem.OrderId = order.Id;
            orderitem.CarId = car.Id;
            orderitem.TotalPrice = car.TotalPrice;
            order.Items.Add(orderitem);

            if (!string.IsNullOrEmpty(user.Email))
            {
                var subject = "درخواستت برای خرید خودرو با موفقیت انجام شد";

                var body = $"سلام {user.UserName ?? "کاربر عزیز"},\n\n" +
                          $"درخواست شما برای خرید خودرو با برند «{car.Brand}» با موفقیت انجام شد.\n" +
                          $"لطفاً برای نهایی شدن خرید، نسبت به پرداخت مبلغ خودرو اقدام فرمایید.\n\n" +
                          $"با تشکر از شما 🌟";

                await _emailNotificationService.SendEmail(user.Email, subject, body);
            }

            await _unitOfWork.VehicleRepository.UpdateAsync(car);

            await _unitOfWork.OrderRepository.AddAsync(order);

            //await _unitOfWork.OrderItemRepository.AddItemAsync(orderitem);

            await _unitOfWork.SaveChangesAsync();

            return order;
        }
    }
}
