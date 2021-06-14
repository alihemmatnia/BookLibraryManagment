using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Data
{
    public class Requests
    {
        public long RequestsId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateBe { get; set; }
        public virtual long BookId { get; set; }
        public virtual long StudentId { get; set; }

    }
}
