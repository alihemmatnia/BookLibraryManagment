using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Dtos
{
    public class AddCategoryDto
    {
        [Required(ErrorMessage ="عنوان دسته بندی الزامی است")]
        [Display(Name ="عنوان دسته بندی")]

        public string Title { get; set; }

    }
}
