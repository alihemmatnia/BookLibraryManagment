using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
    public class DataBaseContext:IdentityDbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Students> Students { get; set; }
        //public DbSet<Requests> Requests { get; set; }
    }
}