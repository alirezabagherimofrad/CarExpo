using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Interfaces.Email_Interface
{
    public interface IEmailNotificationService
    {
        Task SendEmail(string toEmail, string subject, string body);
    }
}
