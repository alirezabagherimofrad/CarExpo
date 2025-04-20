using CarExpo.Application.Commands.Command.PaymentRequestCommand;
using CarExpo.Application.Interfaces.Loyalty_Interface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarExpo.Domain.Models.Users.User;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarExpo.Application.Services.Loyalty_Service
{
    public class LoyaltyService : ILoyaltyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoyaltyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> ApplyLoyalty(PaymentRequestCommand paymentRequestCommand)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(paymentRequestCommand.UserId);

            if (user == null)
                throw new Exception("آیدی کاربر اشتباه هست");

            if (paymentRequestCommand.TotalPrice >= 300000000 && paymentRequestCommand.TotalPrice <= 500000000)
                user.LoyaltyPoints += 1000;
            else if (paymentRequestCommand.TotalPrice > 500000000 && paymentRequestCommand.TotalPrice <= 700000000)
                user.LoyaltyPoints += 2000;
            else if (paymentRequestCommand.TotalPrice > 700000000 && paymentRequestCommand.TotalPrice <= 900000000)
                user.LoyaltyPoints += 3000;
            else if (paymentRequestCommand.TotalPrice > 900000000 && paymentRequestCommand.TotalPrice <= 1200000000)
                user.LoyaltyPoints += 4000;

            if (user.LoyaltyPoints <= 10000)
                user.LoyaltyStatus = Loyaltystatus.Boronz;
            else if (user.LoyaltyPoints <= 50000)
                user.LoyaltyStatus = Loyaltystatus.Silver;
            else
                user.LoyaltyStatus = Loyaltystatus.Gold;

            return user;

        }
    }
}
