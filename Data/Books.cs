using System;
using System.ComponentModel.DataAnnotations;

namespace Book.Data
{
    public class Books
    {
        [Key]
        public long BookId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string Author { get; set; }
        public string PublishDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string  Image { get; set; }
        public bool Status { get; set; } = false;

        public Category Category { get; set; }
        public long CategoryId { get; set; }
        public DateTime DateBe { get; set; }
        public string StudentName { get; set; } = "";
    }
}