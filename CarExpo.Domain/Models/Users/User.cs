using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Users
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {

        }

        public User(string password, string phoneNumber, string email)
        {
            Id = Guid.NewGuid();
            Email = email;
            UserName = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public Guid Id { get; set; }

        public string Password { get; set; }

        public byte[]? File { get; set; }

        public string? FilePath { get; set; }

        public DateTime? BirthDate { get; set; }

        public string ? NationalCode { get; set; }

        public string ? Otp { get; set; }

        public DateTime ? OtpExpiration { get; set; }

        public string OtpGenerator()
        {
            var OtpCode = new Random().Next(100000, 999999);

            return OtpCode.ToString();
        }
    }
}
