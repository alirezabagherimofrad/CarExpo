using Microsoft.AspNetCore.Identity;
using CarExpo.Domain.Models.Vehicles;
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
            Cars = new List<Car>();
        }

        public Guid Id { get; private set; }

        public string Password { get; private set; }

        public byte[]? File { get; private set; }

        public string? FilePath { get; private set; }

        public DateTime? BirthDate { get; private set; }

        public string? NationalCode { get; private set; }

        public int? LoyaltyPoints { get; private set; }

        public loyaltystatus? LoyaltyStatus { get; private set; }

        public bool IsDeleted { get; private set; }

        public string? Otp { get; private set; }

        public DateTime? OtpExpiration { get; private set; }

        public void UpdatePassword(string newpassword)
        {
            Password = newpassword;
        }

        public void softdelete(bool softDelete)
        {
            IsDeleted = softDelete;
        }

        public void loyaltypoints(loyaltystatus loyaltystatus)
        {
            LoyaltyStatus = loyaltystatus;
        }

        public void loyalty(int points)
        {
            LoyaltyPoints += points;
        }

        public void otP(string otp)
        {
            Otp = otp;
        }

        public void time(DateTime otpexpiration)
        {
            OtpExpiration = otpexpiration;
        }

        public void EditInfo(string? email, string? phonenumber, string? password, string? nationalcode)
        {
            if (!string.IsNullOrEmpty(email) && email != "string")
                Email = email;
            if (string.IsNullOrEmpty(phonenumber) && phonenumber != "string")
                PhoneNumber = phonenumber;
            if (!string.IsNullOrEmpty(password) && password != "string")
                Password = password;
            if (!string.IsNullOrEmpty(nationalcode) && nationalcode != "string")
                NationalCode = nationalcode;
        }

        public string OtpGenerator()
        {
            var OtpCode = new Random().Next(100000, 999999);

            return OtpCode.ToString();
        }
        public List<Car> Cars { get; set; }

        public enum loyaltystatus
        {
            Boronz,
            Silver,
            Gold
        }
    }
}
