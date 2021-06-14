using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Dtos
{
    public class AddStudentDto
    {
        [Required(ErrorMessage ="نام دانشجو الزامی است")]
        [Display(Name ="نام دانشجو")]
        public string Name { get; set; }
        [Required(ErrorMessage = "نام خانوادگی دانشجو الزامی است")]
        [Display(Name="نام خانوادگی دانشجو")]
        public string Family { get; set; }
        [Required(ErrorMessage = "نام پدر دانشجو الزامی است")]
        [Display(Name = "نام پدر دانشجو")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "کدملی دانشجو الزامی است")]
        [Display(Name="کدملی دانشجو")]
        public string NationalCode { get; set; }
        [Required(ErrorMessage = "شماره تلفن دانشجو الزامی است")]
        [Display(Name = "شماره تلفن دانشجو")]
        public string PhoneNumber { get; set; }
    }
}
