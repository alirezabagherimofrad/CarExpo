﻿using CarExpo.Application.Commands.Command.UserCommand;
using CarExpo.Application.Interfaces.User_Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarExpo.Controllers.UserController
{
    [ApiController]
    [Route("api/User/[Controller]")]
    public class UserController : ControllerBase
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
            var result = await _userService.RegisterAsync(registerCommand);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _userService.LoginAsync(email, password);
            if (!result.Success) return Unauthorized(result);
            return Ok(result);
        }

        [HttpPost("LoginWithOtp")]
        public async Task<IActionResult> LoginWithOtp(string phoneNumber, string password)
        {
            var result = await _userService.LoginWithOtpAsync(phoneNumber, password);

            if (!result)
                return Unauthorized("نام کاربری یا رمز اشتباه است");

            return Ok("کد تایید ارسال شد");
        }

        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp(string phoneNumber, string code)
        {
            var result = await _userService.VerifyOtpAsync(phoneNumber, code);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(new
            {
                Message = result.Message,
                Token = result.Token
            });
        }

        [HttpPost("SendOtp")]
        public async Task<IActionResult> SendOtpAsync([FromBody] SendOtpCommand sendOtpCommand)
        {
            var userotp = await _otpService.SendOtp(sendOtpCommand);

            return Ok("کد یکبار مصرف با موفقیت ارسال شد");
        }

        //[HttpPost("VerifyOtp")]
        //public async Task<IActionResult> VerifyOtpCodeAsync([FromBody] VerifyOtpCommand verifyOtpCommand)
        //{
        //    var userverify = await _otpService.VerifyOtp(verifyOtpCommand);

        //    return Ok("رمز یکبار مصرف درست وارد شد");
        //}

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

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteAsync(DeleteCommand deleteCommand)
        {
            var user = await _userService.DeleteUser(deleteCommand);
            return Ok("کاربر با موفقیت حذف شد");
        }

        [HttpDelete("SoftDelete")]
        public async Task<IActionResult> SoftDeleteAsync(SoftDeleteCommand softDeleteCommand)
        {
            var user = await _userService.SoftDelete(softDeleteCommand);
            return Ok("حذف منطقی کاربر با موفقیت انجام شد");
        }
    }
}
