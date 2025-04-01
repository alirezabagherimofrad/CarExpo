using CarExpo.Domain.Interfaces;
using CarExpo.Domain.Models.Users;
using CarExpo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<User?> SendOtpAsync(string phoneNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<User?> VerifyOtpAsync(string phoneNumber, string otp)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber && x.Otp == otp);
        }

        public async Task<bool> IsExistAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Set<User>().AnyAsync(predicate);
        }

        public async Task<User?> UpdateUserInfoAsync(string phoneNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<User?> ResetPasswordAsync(string phoneNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<User?> RecoverPasswordAsync(string phoneNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<User> RegisterAsync(User user)
        {
            _context.Users.AddAsync(user);

             await _context.SaveChangesAsync();

            return user;
        }
    }
}
