using SharpNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Services
{
    public interface IUserService
    {
        Kernel.UserInfoKernel GetByUsername(string username);

        void Delete(int noteID);

        void Create(Models.UserInfo user);

        void Update(Models.UserInfo user);

        IEnumerable<Models.UserInfo> GetSelection(int offset, int size);

        string GetToken(LoginForm form);

        void Register(Models.RegistrationForm form);
    }
}
