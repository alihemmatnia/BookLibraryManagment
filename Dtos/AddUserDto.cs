using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Dtos
{
    public class AddUserDto
    {
        [Required(ErrorMessage ="نام کاربری الزامی است")]
        [Display(Name="نام کاربری")]
        public string Username{ get; set; }
        [Required(ErrorMessage = "نام  الزامی است")]
        [Display(Name = "نام ")]
        public string Name { get; set; }
        [Required(ErrorMessage ="ایمیل  الزامی است")]
        [Display(Name="ایمیل ")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage = "شمار تلفن الزامی است")]
        [Display(Name = "شماره تلفن ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
