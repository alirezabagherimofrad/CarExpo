﻿using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers
{
    [ApiController]
    [Route("api/User/[Controller]")]
    public class UserController : Controller
    {
        private readonly IuserService _userService;
        private readonly IOtpService _otpService;
        public UserController(IOtpService otpService, IuserService userService)
        {
            _otpService = otpService;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand registerCommand)
        {
            try
            {
                registerCommand.Validate();

                var result = await _userService.RegisterAsync(registerCommand);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SendOtp")]
        public async Task<IActionResult> SendOtpAsync([FromBody] SendOtpCommand sendOtpCommand)
        {
            try
            {
                var userotp = await _otpService.SendOtp(sendOtpCommand);

                return Ok("کد یکبار مصرف با موفقیت ارسال شد");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtpCodeAsync([FromBody] VerifyOtpCommand verifyOtpCommand)
        {
            try
            {
                var userverify = await _otpService.VerifyOtp(verifyOtpCommand);

                return Ok("رمز یکبار مصرف درست وارد شد");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateUserInfo")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserInformatiobCommand updateUserInfoCommand)
        {
            var user = await _userService.UpdateUserInfo(updateUserInfoCommand);
            return Ok("اطلاعات کاربر با موفقیت به روز رسانی شد");
        }

        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordCommand resetPasswordCommand)
        {
            var user = await _userService.ResetPassword(resetPasswordCommand);
            return Ok("بازنشانی رمز عبور با موفقیت انجام شد");
        }

        [HttpPut("RecoverPassword")]
        public async Task<IActionResult> RecoverPasswordAsync(RecoverPasswordCommand recoverPasswordCommand)
        {
            var user = await _userService.RecoverPassword(recoverPasswordCommand);
            return Ok("بازیابی رمز عبور شما با موفقیت انجام شد");
        }
        
    }
}
