using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SharpNote.UOW;
using SharpNote.Models;
using Microsoft.IdentityModel.Tokens;

namespace SharpNote.Services
{
    public class UserService : IUserService
    {

        private UnitOfWork _uniteOfWork;

        public UserService()
        {
            _uniteOfWork = new UnitOfWork();
        }

        public Models.UserInfo GetByUsername(string username)
        {
            var user = _uniteOfWork.Users.Get(username);
            return ViewModelMapper.ToModel(user);
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

        public void Login(LoginForm form)
        {
            var user = _uniteOfWork.Users.Get(form.Username);
            if (user?.Password.Equals(form.Password) ?? false)
            {
                // DO LOGIN
            }
        }
    }
}
