using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Models
{
    public class UserInfoModel : EntityModel
    {
        public string Username { get; set; }
        public ICollection<NoteModel> Notes { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
