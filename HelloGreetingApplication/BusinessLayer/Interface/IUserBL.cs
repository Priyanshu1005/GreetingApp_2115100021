using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserModel RegisterUser(RegisterModel userRegistration);
        public UserModel LoginUser(LoginModel userLoginDto);
        public Task<string> ForgetPassword(string email);
        public bool ResetPassword(string newPassword, string token);
    }
}