using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models
{
    public class OtpEntry
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime ExpireAt { get; set; }
        public bool IsUsed { get; set; }
    }
}
