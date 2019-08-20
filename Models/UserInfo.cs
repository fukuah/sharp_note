using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Models
{
    public class UserInfo
    {
        public string Username { get; set; }
        public ICollection<Note> Notes { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
