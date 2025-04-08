﻿using CarExpo.Domain.Models.Users;
using CarExpo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> SendOtpAsync(string phoneNumber);

        Task<User?> VerifyOtpAsync(string phoneNumber, string otp);

        Task<bool> IsExistAsync(Expression<Func<User, bool>> predicate);

        Task<User?> UpdateUserInfoAsync(string phoneNumber);

        Task<User?> ResetPasswordAsync(string phoneNumber);

        Task<User?> RecoverPasswordAsync(string phoneNumber);

        Task <User?> RegisterAsync(User user);
    }
}
