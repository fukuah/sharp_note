using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharpNote.AppDbContext.Entities
{
    public class User : CommonEntity
    {
        [Required, MaxLength(100)]
        public string Username { get; set; }
        [Required, MaxLength(100)]
        public byte [] PasswordHash { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
