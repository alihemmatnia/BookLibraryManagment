using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Dtos
{
    public class AddReceivershipDto
    {
        [Display(Name ="شماره کتاب را وارد کنید ")]
        [Required(ErrorMessage ="شماره کتاب الزامی است")]
        [DataType(DataType.Text)]
        public int BookId { get; set; }
        [Display(Name = "شماره دانش اموز را وارد کنید ")]
        [Required(ErrorMessage = "شماره دانش اموز الزامی است")]
        [DataType(DataType.Text)]
        public int StudentId { get; set; }
    }
}
