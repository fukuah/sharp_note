﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SharpNote.UOW;
using SharpNote.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using SharpNote.AppDbContext;
using SharpNote.Kernel;
using SharpNote.AppDbContext.Entities;

namespace SharpNote.Services
{
    public class UserService : IUserService
    {
        public UserInfoKernel GetByUsername(string username)
        {
            User user;
            using (var uow = new UnitOfWork())
            {
                user = uow.Users.Get(username);
            }
            return user?.ToKernel();
        }

        public void Create(UserInfoModel user)
        {
            throw new NotImplementedException();    
        }

        public void Delete(int noteID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInfoModel> GetSelection(int offset, int size)
        {
            throw new NotImplementedException();
        }

        public void Update(UserInfoModel user)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(LoginFormModel form)
        {
            User user;
            using (var uow = new UnitOfWork())
            {
                user = uow.Users.Get(form.Username);
            }
            // Convert to Base64String for comparison
            var formHash = System.Convert.ToBase64String(this.GetPasswordHash(form.Password));
            var userHash = System.Convert.ToBase64String(user?.PasswordHash ?? new byte[0]);
            if (userHash.Equals(formHash))
            {
                return true;
            }

            return false;
        }



        public void Register(RegistrationFormModel form)
        {
            var user = new User
            {
                Username = form.Username,
                PasswordHash = GetPasswordHash(form.Password)
            };
            using (var uow = new UnitOfWork())
            {
                uow.Users.Create(user);
            }
        }

        private byte [] GetPasswordHash(string password)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            return sha.ComputeHash(passwordBytes);
        }
    }
}
