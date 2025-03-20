using BusinessLayer.Interface;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private IUserRL _userRl;
        //private readonly ILogger<UserBL> _logger;

        public UserBL(IUserRL userRl, ILogger<UserBL> logger)
        {
            _userRl = userRl;
            //_logger = logger;
        }

        public UserModel RegisterUser(RegisterModel registerModel)
        {
            var user = _userRl.RegisterUser(registerModel);
            if (user != null)
            {
                return new UserModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
            }
            return null;
        }

        public UserModel LoginUser(LoginModel userLoginDto)
        {
            return _userRl.LoginUser(userLoginDto);
        }

        public Task<string> ForgetPassword(string email)
        {
            throw new NotImplementedException();
        }
        public bool ResetPassword(string newPassword, string token)
        {
            throw new NotImplementedException();
        }
    }
}