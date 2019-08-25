using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharpNote.AppDbContext.Entities
{
    public class Note : CommonEntity
    {
        [Required, MaxLength(200)]
        public string Header { get; set; }
        [Required]
        public string Content { get; set; }
        public string Link { get; set; }
        public User Creator { get; set; }
        //public ICollection<User> Permissions { get; set; }

        public DateTime? AppearAt { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
