using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Kernel
{
    public class NoteKernel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public UserKernel Creator { get; set; }
        public List<UserKernel> Permissions;

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public DateTime? AppearAt { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
