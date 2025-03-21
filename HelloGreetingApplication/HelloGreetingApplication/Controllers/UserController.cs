﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using BusinessLayer.Interface;

namespace HelloGreetingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserBL userBL, ILogger<UserController> logger)
        {
            _userBL = userBL;
            _logger = logger;
        }

        /// <summary>
        ///  Registers a new user.
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns>first name, last name, email</returns>

        [HttpPost]
        public IActionResult Registration(RegisterModel registrationModel)
        {
            var result = _userBL.RegisterUser(registrationModel);
            if (result != null)
            {
                var response = new ResponseModel<UserModel>
                {
                    Success = true,
                    Message = "User Registered Successfully",
                    Data = result
                };
                return Ok(response);
            }

            return BadRequest(new ResponseModel<UserModel>
            {
                Success = false,
                Message = "Could not register"
            });
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns>response model</returns>
        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = _userBL.LoginUser(loginModel);
            if (user != null)
            {
                return Ok(new ResponseModel<bool>
                {
                    Success = true,
                    Message = "Login successful",
                    Data = true
                });
            }
            return Unauthorized(new ResponseModel<bool>
            {
                Success = false,
                Message = "Login failed"
            });
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel passwordModel)
        {
            throw new System.NotImplementedException();
        }

        [HttpPatch("resetpassword")]
        public IActionResult ResetPassword([FromQuery] int userId, ResetPasswordModel resetModel)
        {
            throw new System.NotImplementedException();
        }
    }
}