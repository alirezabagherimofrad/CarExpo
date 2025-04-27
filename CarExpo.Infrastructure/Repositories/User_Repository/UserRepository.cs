using CarExpo.Domain.Interfaces.UserRepository;
using CarExpo.Domain.Models.Users;
using CarExpo.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Repositories.User_Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(DataBaseContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }


        public async Task<User?> SendOtpAsync(string phoneNumber)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<User?> VerifyOtpAsync(string phoneNumber, string otp)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber && x.Otp == otp);
        }

        public async Task<bool> IsExistAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Set<User>().AnyAsync(predicate);
        }

        public async Task<User?> UpdateUserInfoAsync(string phoneNumber)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<User?> ResetPasswordAsync(string phoneNumber)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<User?> RecoverPasswordAsync(string phoneNumber)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<User?> SoftDeleteAsync(Guid Id)
        {
            return await _userManager.FindByIdAsync(Id.ToString());
        }
    }
}
