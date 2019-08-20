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

        void Create(Models.UserInfoModel user);

        void Update(Models.UserInfoModel user);

        IEnumerable<Models.UserInfoModel> GetSelection(int offset, int size);

        bool UserExists(LoginForm form);

        void Register(Models.RegistrationForm form);
    }
}
