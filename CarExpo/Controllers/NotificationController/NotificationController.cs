using CarExpo.Application.Interfaces.Email_Interface;
using CarExpo.Application.Interfaces.User_Interface;
using CarExpo.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.NotificationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IuserService _userService;
        private readonly IEmailNotificationService _emailNotificationService;
        private readonly IUnitOfWork _unitOfWork;
        public NotificationController(IuserService userService, IEmailNotificationService emailNotificationService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _emailNotificationService = emailNotificationService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("SendEmailToUser")]
        public async Task<IActionResult> SendEmailToUser(Guid userId)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

            if (user == null)
                return NotFound("کاربری با این آیدی پیدا نشد");

            var subject = "سلام از CarExpo 👋";
            var body = $"سلام {user.UserName}، خرید ماشینت در حال بررسیه سلطان! 😎";

            await _emailNotificationService.SendEmail(user.Email, subject, body);

            return Ok("ایمیل با موفقیت ارسال شد");
        }
    }
}
