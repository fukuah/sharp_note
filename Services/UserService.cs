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
        private readonly IAuthService _authService;
            
        public UserService(IAuthService authService)
        {
            _unitOfWork = new UnitOfWork();
            _authService = authService;
        }

        public Kernel.UserInfoKernel GetByUsername(string username)
        {
            var user = _unitOfWork.Users.Get(username);
            return user.ToKernel();
        }

        public void Create(UserInfo user)
        {
            throw new NotImplementedException();    
        }

        public void Delete(int noteID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInfo> GetSelection(int offset, int size)
        {
            throw new NotImplementedException();
        }

        public void Update(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public string GetToken(LoginForm form)
        {
            var user = _unitOfWork.Users.Get(form.Username);
            // Convert to Base64String for comparison
            var formHash = System.Convert.ToBase64String(this.getPasswordHash(form.Password));
            var userHash = System.Convert.ToBase64String(user?.PasswordHash ?? new byte[0]);
            if (userHash.Equals(formHash))
            {
                return _authService.GenerateToken(form.Username);
            }

            return "";
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
