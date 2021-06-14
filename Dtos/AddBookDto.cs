using System.ComponentModel.DataAnnotations;

namespace Book.Dtos
{
    public class AddBookDto
    {

        [Display(Name ="عنوان")]
[Required(ErrorMessage="عنوان کتاب الزامی است")]

        public string Title { get; set; }   
[Display(Name ="توضیحات کتاب")]
[Required(ErrorMessage="نوضیحات کتاب الزامی است")]

        public string Content { get; set; }   
[Display(Name ="نویسنده")]
[Required(ErrorMessage="نویسنده کتاب الزامی است")]

public string Author { get; set; }
[Display(Name = "تاریخ انتشار کتاب مثال (1400/03/18)")]
[Required(ErrorMessage="تاریخ انتشار کتاب الزامی است")]
public string PublishDate { get; set; }
[Display(Name ="تصویر کتاب")]
public string ImageName { get; set; }

[Display(Name ="دسته بندی ")]
public int CategoryId{ get; set; }
    }
}

