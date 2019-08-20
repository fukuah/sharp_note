using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Services
{
    public interface IAuthService
    {
        string GenerateToken(string username);
    }
}
