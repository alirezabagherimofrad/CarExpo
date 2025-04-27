using AutoMapper;
using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Application.Dto.UserDto;
using CarExpo.Application.Interfaces.User_Interface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Domain.Models.Users;
using CarExpo.Infrastructure;
using CarExpo.Infrastructure.Authentication;
using CarExpo.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.USER_SERVICE
{

    public class UserService : IuserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly MeliPayamakService _smsService;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, DataBaseContext dbContext, UserManager<User> userManager, MeliPayamakService smsService, SignInManager<User> signInManager, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dbContext = dbContext;
            _userManager = userManager;
            _smsService = smsService;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<RegisterDto> RegisterAsync(RegisterCommand registerCommand)
        {
            registerCommand.Validate();

            var emailExists = await _unitOfWork.UserRepository.IsExistAsync(u => u.Email == registerCommand.Email);
            if (emailExists)
                throw new Exception("این ایمیل قبلاً ثبت شده است.");

            var phoneExists = await _unitOfWork.UserRepository.IsExistAsync(u => u.PhoneNumber == registerCommand.PhoneNumber);

            if (phoneExists)
                throw new Exception("این شماره موبایل قبلاً ثبت شده است.");

            var user = _mapper.Map<User>(registerCommand);

            var result = await _userManager.CreateAsync(user, registerCommand.Password);

            var registerDto = _mapper.Map<RegisterDto>(user);

            return registerDto;

        }


        public async Task<bool> LoginWithOtpAsync(string phoneNumber, string password)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user == null) return false;

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid) return false;

            var otpCode = new Random().Next(100000, 999999).ToString();

            _dbContext.OtpEntries.Add(new Domain.Models.OtpEntry
            {
                PhoneNumber = phoneNumber,
                Code = otpCode,
                ExpireAt = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            });
            await _unitOfWork.SaveChangesAsync();
            var smsClient = new MeliPayamakService("09192172990", "Yazahra@110");
            var res = await smsClient.SendByBaseNumberAsync(otpCode, phoneNumber, 39885);
            Console.WriteLine($"{phoneNumber} : {otpCode}");
            return true;
        }

        public async Task<(bool Success, string? Token, string? Message)> VerifyOtpAsync(string phoneNumber, string code)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user == null)
                return (false, null, "کاربر یافت نشد");

            var otp = await _dbContext.OtpEntries
                .Where(x => x.PhoneNumber == phoneNumber && x.Code == code && !x.IsUsed && x.ExpireAt > DateTime.UtcNow)
                .OrderByDescending(x => x.ExpireAt)
                .FirstOrDefaultAsync();

            if (otp == null)
                return (false, null, "کد وارد شده صحیح نیست یا منقضی شده است");

            otp.IsUsed = true;
            await _unitOfWork.SaveChangesAsync();

            var token = await _jwtService.GenerateToken(user.Id);
            return (true, token, "ورود موفقیت‌آمیز بود");
        }

        public async Task<User> UpdateUserInfo(UpdateUserInformatiobCommand updateUserInfoCommand)
        {
            var user = await _unitOfWork.UserRepository.UpdateUserInfoAsync(updateUserInfoCommand.PhoneNumber);

            if (user == null)
                throw new Exception("کاربری به این شماره پیدا نشد");

            if (user.Email == updateUserInfoCommand.Email)
                throw new Exception("ایمیل کاربر نمی تواند تکراری باشد");

            if (user.Password == updateUserInfoCommand.Password)
                throw new Exception("رمز کاربر نمی تواند تکراری باشد");

            if (user.PhoneNumber == updateUserInfoCommand.PhoneNumber)
                throw new Exception("شماره همراه کاربر نمی تواند تکراری باشد");

            if (user.Otp != updateUserInfoCommand.Otp)
                throw new Exception("رمز یکبار مصرف اشتباه هست");

            if (user.OtpExpiration < DateTime.Now)
                throw new Exception("کد یکبار مصرف منقضی شده است");

            user.EditInfo(
                updateUserInfoCommand.Email,
                updateUserInfoCommand.PhoneNumber,
                updateUserInfoCommand.Password,
                updateUserInfoCommand.Nationalcode
                );

            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<User?> ResetPassword(ResetPasswordCommand resetPasswordCommand)
        {
            var user = await _unitOfWork.UserRepository.ResetPasswordAsync(resetPasswordCommand.PhoneNumber);

            if (user == null)
                throw new Exception("کاربری به این شماره پیدا نشد");

            if (user.Otp != resetPasswordCommand.Otp)
                throw new Exception("رمز یکبار مصرف اشتباه هست");

            if (user.OtpExpiration < DateTime.Now)
                throw new Exception("کد یکبار مصرف منقضی شده است");

            if (user.Password != resetPasswordCommand.Password)
                throw new Exception("پسورد شما نادرست هست");

            if (user.Password != resetPasswordCommand.NewPassword)
                user.UpdatePassword(resetPasswordCommand.NewPassword);

            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<User?> RecoverPassword(RecoverPasswordCommand recoverPasswordCommand)
        {
            var user = await _unitOfWork.UserRepository.RecoverPasswordAsync(recoverPasswordCommand.PhoneNumber);

            if (user == null)
                throw new Exception("کاربری به این شماره پیدا نشد");

            if (user.Otp != recoverPasswordCommand.Otp)
                throw new Exception("رمز یکبار مصرف اشتباه هست");

            if (user.OtpExpiration < DateTime.Now)
                throw new Exception("کد یکبار مصرف منقضی شده است");

            if (user.Password == recoverPasswordCommand.NewPassword)
                throw new Exception("پسورد قدیم با پسورد جدید شما نباید برابر هست");

            user.UpdatePassword(recoverPasswordCommand.NewPassword);

            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteUser(DeleteCommand deleteCommand)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(deleteCommand.Id);

            if (user == null) throw new Exception("همچین کاربری با این آیدی باری حذف کردن وجود ندارد");

            await _unitOfWork.UserRepository.DeleteAsync(user);

            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<User?> SoftDelete(SoftDeleteCommand softDeleteCommand)
        {
            var user = await _unitOfWork.UserRepository.SoftDeleteAsync(softDeleteCommand.Id);

            if (user == null) throw new Exception("کاربری با این ایمیل یافت نشد");

            user.softdelete(true);

            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<AuthResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new AuthResult { Success = false, ErrorMessage = "کاربر یافت نشد." };

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                return new AuthResult { Success = false, ErrorMessage = "رمز عبور اشتباه است." };


            var token = await _jwtService.GenerateToken(user.Id);
            //var token = await _jwtService.GenerateToken(user);
            return new AuthResult { Success = true, Token = token };

        }
    }
}
