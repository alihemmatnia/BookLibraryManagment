using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Book.Data
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; } 
        public string Title { get; set; }
        public ICollection<Books> Books { get; set; }
        
    }
}