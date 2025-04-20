using CarExpo.Application.Commands.Command.InvoiceCommand;
using CarExpo.Application.Dto.InvoiceDto;
using CarExpo.Application.Interfaces.Email_Interface;
using CarExpo.Application.Interfaces.Invoice__Interface;
using CarExpo.Domain.Interfaces.UnitOfWorkInterface;
using CarExpo.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Services.Invoice_Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailNotificationService _emailNotificationService;
        public InvoiceService(IUnitOfWork unitOfWork, IEmailNotificationService emailNotificationService)
        {
            _unitOfWork = unitOfWork;
            _emailNotificationService = emailNotificationService;
        }
        public async Task<InvoiceCommandDto> Payment(InvoiceCommand invoiceCommand)
        {
            var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(invoiceCommand.PaymentId);

            var user = await _unitOfWork.UserRepository.GetByIdAsync(invoiceCommand.UserId);

            if (payment == null) throw new Exception("آیدی پرداخت اشتباه هست و یا وجود ندارد");

            if (user == null) throw new Exception("آیدی کاربر اشتباه هست و یا وجودد ندارد");

            if (!string.IsNullOrEmpty(user.Email))
            {
                var subject = "سلام رسید فاکتور خرید و کدپیگیری خرید شما با موفقیت ارسال شد";

                var body = $"{payment.InvoiceNumber},{payment.TrackingCode}";

                await _emailNotificationService.SendEmail(user.Email, subject, body);
            }
            var dto = new InvoiceCommandDto
            {
                Id = payment.Id,
                UserId = payment.UserId,
            };
            return dto;
        }
    }
}
