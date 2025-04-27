using AutoMapper;
using CarExpo.Application.Commands.Command.OrserCommand;
using CarExpo.Application.Interfaces.Email_Interface;
using CarExpo.Application.Interfaces.Order_Interface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Domain.Models;
using CarExpo.Domain.Models.Orders;
using CarExpo.Domain.Models.Vehicles;
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

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IEmailNotificationService emailNotificationService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
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

            order.paid(false);

            car.updatestatus(salestatus.pendingreview);

            order.price(car);

            var orderitem = new OrderItem();
            orderitem.orderid(order.Id);
            orderitem.carid(car.Id);
            orderitem.price(car.TotalPrice);
            order.Items.Add(orderitem);


            if (!string.IsNullOrEmpty(user.Email))
            {
                var subject = "درخواستت برای خرید خودرو با موفقیت انجام شد";

                var body = $"سلام {user.UserName ?? "کاربر عزیز"},\n\n" +
                          $"درخواست شما برای خرید خودرو با برند «{car.Brand}» با موفقیت انجام شد.\n" +
                          $"لطفاً برای نهایی شدن خرید، نسبت به پرداخت مبلغ خودرو اقدام فرمایید.\n\n" +
                          $"با تشکر از شما ";

                await _emailNotificationService.SendEmail(user.Email, subject, body);

                var notif = new Notification(user.Id, subject, body);

                await _unitOfWork.NotificationRepository.AddAsync(notif);
            }

            await _unitOfWork.VehicleRepository.UpdateAsync(car); // از این استفاد

            await _unitOfWork.OrderRepository.AddAsync(order);

            await _unitOfWork.SaveChangesAsync();

            return order;
        }
    }
}
