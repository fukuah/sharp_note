using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Models
{
    public class NoteModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string Username { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? AppearAt { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
