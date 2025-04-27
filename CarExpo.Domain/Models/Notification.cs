using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Domain.Models
{
    public class Notification
    {
        public Notification()
        {
            
        }
        public Notification(Guid userid, string subJect, string Message)
        {
            Id =Guid.NewGuid();
            UserId = userid;
            subject = subJect;
            message = Message;
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string? subject { get; set; }

        public string? message { get; set; }
    }
}
