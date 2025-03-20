using Microsoft.Extensions.Configuration;
using ModelLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Hashing;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly HelloGreetingContext _dbContext;
        private readonly Password_Hash _passwordHash;

        public UserRL(HelloGreetingContext context, IConfiguration config, Password_Hash hash)
        {
            _dbContext = context;
            _passwordHash = hash;
        }


        public UserEntity RegisterUser(RegisterModel userRegistrationDto)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(e => e.Email == userRegistrationDto.Email);

            if (existingUser == null)
            {
                var newUser = new UserEntity
                {
                    FirstName = userRegistrationDto.FirstName,
                    LastName = userRegistrationDto.LastName,
                    Email = userRegistrationDto.Email,
                    PasswordHash = _passwordHash.PasswordHashing(userRegistrationDto.Password)
                };

                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();

                return newUser;
            }
            return null;
        }

        public UserModel LoginUser(LoginModel userLoginDto)
        {
            var validUser = _dbContext.Users.FirstOrDefault(e => e.Email == userLoginDto.Email);
            if (validUser != null)
            {
                if (_passwordHash.VerifyPassword(userLoginDto.Password, validUser.PasswordHash))
                {
                    return new UserModel()
                    {
                        FirstName = validUser.FirstName,
                        LastName = validUser.LastName,
                        Email = validUser.Email
                    };
                }

            }
            return null;
        }

        public Task<string> ForgetPassword(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool ResetPassword(string newPassword, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}