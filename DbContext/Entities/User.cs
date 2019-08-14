using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharpNote.AppDbContext.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required, MaxLength(100)]
        public string Username { get; set; }
        public ICollection<Note> Notes { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
