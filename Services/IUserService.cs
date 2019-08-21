using SharpNote.Kernel;
using SharpNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Services
{
    public interface IUserService
    {
        UserInfoKernel GetByUsername(string username);

        void Delete(int noteID);

        void Create(UserInfoKernel user);

        void Update(UserInfoKernel user);

        IEnumerable<UserInfoKernel> GetSelection(int offset, int size);

        bool UserExists(string username, string password);

        void Register(string username, string password);
    }
}
