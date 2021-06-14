using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage ="نام کاربری الزامی است")]
        [Display(Name ="نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Rem { get; set; }
    }
}
