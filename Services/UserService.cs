using System;
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

namespace SharpNote.Services
{
    public class UserService : IUserService
    {
        private UnitOfWork _unitOfWork;
            
        public UserService(IAuthService authService)
        {
            _unitOfWork = new UnitOfWork();
        }

        public Kernel.UserInfoKernel GetByUsername(string username)
        {
            var user = _unitOfWork.Users.Get(username);
            return user.ToKernel();
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

        public bool UserExists(LoginForm form)
        {
            var user = _unitOfWork.Users.Get(form.Username);
            // Convert to Base64String for comparison
            var formHash = System.Convert.ToBase64String(this.getPasswordHash(form.Password));
            var userHash = System.Convert.ToBase64String(user?.PasswordHash ?? new byte[0]);
            if (userHash.Equals(formHash))
            {
                return true;
            }

            return false;
        }



        public void Register(RegistrationForm form)
        {
            var user = new AppDbContext.Entities.User
            {
                Username = form.Username,
                PasswordHash = getPasswordHash(form.Password)
            };

            _unitOfWork.Users.Create(user);
        }

        private byte [] getPasswordHash(string password)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            return sha.ComputeHash(passwordBytes);
        }
    }
}
