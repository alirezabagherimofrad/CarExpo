﻿using AutoMapper;
using CarExpo.Application.Commands.Command.PaymentRequestCommand;
using CarExpo.Application.Interfaces.Email_Interface;
using CarExpo.Application.Interfaces.Payment_Interface;
using CarExpo.Domain.Models.Payment;
using CarExpo.Domain.Models.Vehicles;
using CarExpo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.PAYMENT_SERVICE
{
    public class PaymentService : IPaymentService
    {
        private readonly IEmailNotificationService _emailNotificationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentService(IEmailNotificationService emailNotificationService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _emailNotificationService = emailNotificationService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Payment> Payment(PaymentRequestCommand paymentRequestCommand)
        {
            paymentRequestCommand.Validate();

            var user = await _unitOfWork.UserRepository.GetByIdAsync(paymentRequestCommand.UserId);

            var car = await _unitOfWork.VehicleRepository.GetByIdAsync(paymentRequestCommand.CarId);

            var order = await _unitOfWork.OrderRepository.GetByIdAsync(paymentRequestCommand.OrderId);

            if (user == null)
                throw new Exception("همچین آیدی برای یوزر وجود ندارد");

            if (user.Id != paymentRequestCommand.UserId)
                throw new Exception("آیدی یوزر اشتباه وارد شده است");

            if (order == null)
                throw new Exception("همچین آیدی سفارشی وجود ندارد");

            if (order.Id != paymentRequestCommand.OrderId)
                throw new Exception("آیدی سفارش اشتباه هست");

            if (car == null)
                throw new Exception("همچین ماشینی با این آیدی وجود ندارد");

            if (user.Id != paymentRequestCommand.UserId)
                throw new Exception("آیدی کاربر درست وارد نشده");

            if (car.Id != paymentRequestCommand.CarId)
                throw new Exception("آیدی ماشین اشتباه هست آیدی درست را وارد نمایید");

            if (car.TotalPrice != paymentRequestCommand.TotalPrice)
                throw new Exception("مبلغ ماشین درست ارسال نشده");

            if (car.TotalPrice > paymentRequestCommand.TotalPrice)
                throw new Exception("مبلغ وارد شده کمتر از مبلغ اصلی ماشین می باشد لطفا مبلغ اصلی ماشین را جهت پرداخت وارد نمایید");

            if (car.TotalPrice < paymentRequestCommand.TotalPrice)
                throw new Exception("مبلغ پرداخت شده بیشتر از مبلغ اصلی هست لطفا مبلغ اصلی را ارسال نمایید ");

            var payment = _mapper.Map<Payment>(paymentRequestCommand);

            payment.Id = Guid.NewGuid();

            payment.TimeOfpayment = DateTime.Now;

            car.Salestatus = salestatus.Purchased;

            order.IsPaid = true;

            if (!string.IsNullOrEmpty(user.Email))
            {
                var subjectBuyer = "پرداخت شما با موفقیت انجام شد - CarExpo";

                var body = $"سلام {user.UserName ?? "کاربر عزیز"},\n\n" + $"{payment.InvoiceNumber} :شماره فاکتور" + $"{payment.TrackingCode} کد رهگیری سفارش ";

                await _emailNotificationService.SendEmail(user.Email, subjectBuyer, body);
            }

            var seller = await _unitOfWork.UserRepository.GetByIdAsync(car.UserId);

            if (seller != null && !string.IsNullOrEmpty(seller.Email))
            {
                var subjectSeller = "ماشین شما با موفقیت به فروش رسید - CarExpo";

                var bodySeller = $"سلام {seller.UserName ?? "کاربر گرامی"},\n\n" + "تا چند ساعت آینده پول مبلغ مورد نظر به حساب شما واریز خواهد شد";

                await _emailNotificationService.SendEmail(seller.Email, subjectSeller, bodySeller);
            }

            await _unitOfWork.VehicleRepository.UpdateAsync(car);

            await _unitOfWork.OrderRepository.UpdateAsync(order);

            await _unitOfWork.PaymentRepository.AddAsync(payment);

            await _unitOfWork.PaymentRepository.UpdateAsync(payment);

            await _unitOfWork.SaveChangesAsync();

            return payment;
        }
    }
}