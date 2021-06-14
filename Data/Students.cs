using System.ComponentModel.DataAnnotations;

namespace Book.Data
{
    public class Students
    {
        [Key]
        public long StudentId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }

    }
}