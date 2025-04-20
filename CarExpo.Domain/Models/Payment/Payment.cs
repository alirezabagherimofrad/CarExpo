using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models.Payment
{
    public class Payment
    {
        public Payment()
        {
            Id = Guid.NewGuid();
            TimeOfpayment = DateTime.Now;
            InvoiceNumber = GenerateInvoiceNumber();
            TrackingCode = GenerateTrackingCode();
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public Guid OrderId { get; set; }
        public string? CardNumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime TimeOfpayment { get; set; }
        public string InvoiceNumber { get; set; }
        public string TrackingCode { get; set; }


        public static readonly Random _random = new();

        public static string RandomLetters(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public static string GenerateInvoiceNumber()
        {
            var letters = RandomLetters(3);
            var randomLetter = RandomLetters(1);
            var numbers = _random.Next(10000, 99999);
            return $"{letters}-{randomLetter}-{numbers}";
        }

        public static string GenerateTrackingCode()
        {
            var letters = RandomLetters(3);
            var randomLetter = RandomLetters(1);
            var numbers = _random.Next(10000, 99999);
            return $"{letters}-{randomLetter}-{numbers}";
        }
    }
}
