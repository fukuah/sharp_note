using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Models
{
    public class RegistrationForm
    {
        [Required(ErrorMessage = "Username was not provided.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password was not provided.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are not the same.")]
        public string ConfirmPassword { get; set; }
    }
}
