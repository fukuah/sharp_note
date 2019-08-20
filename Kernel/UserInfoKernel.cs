using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Kernel
{
    public class UserInfoKernel
    {
        public string Username { get; set; }
        public List<NoteKernel> Notes { get; set; }
        public ICollection<UserKernel> Friends { get; set; }
        public DateTime? CreatedAt { get; set; }

        public UserKernel ToUserKernel()
        {
            return new UserKernel
            {
                Username = this.Username
            };
        }
    }
}
