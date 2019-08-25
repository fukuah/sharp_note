using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.AppDbContext.Entities
{
    public class NotePermission : CommonEntity
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
    }
}
