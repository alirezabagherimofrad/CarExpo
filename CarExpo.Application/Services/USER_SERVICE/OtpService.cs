using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Application.Interfaces.User_Interface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Domain.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.USER_SERVICE
{
    public class OtpService : IOtpService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OtpService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public async Task<User> SendOtp(SendOtpCommand sendOtpCommand)
        {
            var user = await _unitOfWork.UserRepository.SendOtpAsync(sendOtpCommand.PhoneNumber);

            if (user == null)
            {
                throw new Exception("کاربر با این شماره همراه یافت نشد");
            }

            user.OtpExpiration = DateTime.Now.AddMinutes(60);

            var otpcode = user.OtpGenerator();

            user.Otp = otpcode;

            await _unitOfWork.UserRepository.UpdateAsync(user);

            return user;
        }

        public async Task<User> VerifyOtp(VerifyOtpCommand verifyOtpCommand)
        {
            var user = await _unitOfWork.UserRepository.VerifyOtpAsync(verifyOtpCommand.PhoneNumber, verifyOtpCommand.Otp);

            if (user == null)
                throw new Exception("کاربری با این شماره همراه پیدا نشد");

            if (user.Otp != verifyOtpCommand.Otp)
                throw new Exception("کد یکبار مصرف شما اشتباه هست");

            if (user.OtpExpiration < DateTime.Now)
                throw new Exception("کد یکبار مصرف شما منقضی شده");

            return user;
        }
    }
}
