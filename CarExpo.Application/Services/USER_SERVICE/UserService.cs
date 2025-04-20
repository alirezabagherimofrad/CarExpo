using AutoMapper;
using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Application.Dto.UserDto;
using CarExpo.Application.Interfaces.User_Interface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Domain.Models.Users;
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
        private readonly UserManager<User> _userManager;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
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

            user.UserName = registerCommand.Email;
            user.NormalizedEmail = registerCommand.Email.ToUpper();
            user.NormalizedUserName = registerCommand.Email.ToUpper();
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, registerCommand.Password);

            var createdUser = await _unitOfWork.UserRepository.RegisterAsync(user);

            var registerDto = _mapper.Map<RegisterDto>(createdUser);

            return registerDto;

        }


        public async Task<User> UpdateAsync(User user)
        {
            var repo = _unitOfWork.Repository<User>();

            var result = await repo.UpdateAsync(user);

            return result;
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

            if (!string.IsNullOrEmpty(updateUserInfoCommand.Password))
                user.Password = updateUserInfoCommand.Password;

            if (!string.IsNullOrEmpty(updateUserInfoCommand.Email))
                user.Email = updateUserInfoCommand.Email;

            await _unitOfWork.UserRepository.UpdateAsync(user);

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

            if (user.Password == resetPasswordCommand.Password)
                user.Password = resetPasswordCommand.NewPassword;

            if (user.Password == resetPasswordCommand.NewPassword)
                throw new Exception("پسورد قدیم با پسورد جدید شما برابر هست");

            await _unitOfWork.UserRepository.UpdateAsync(user);

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

            var newpassword = recoverPasswordCommand.NewPassword;

            user.Password = newpassword;

            await _unitOfWork.UserRepository.UpdateAsync(user);

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

            user.IsDeleted = true;

            await _unitOfWork.UserRepository.UpdateAsync(user);

            await _unitOfWork.SaveChangesAsync();

            return user;
        }
    }
}
