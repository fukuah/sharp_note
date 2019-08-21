using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Models
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = "Username is not provided.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is not provided.")]
        public string Password { get; set; }
    }
}
