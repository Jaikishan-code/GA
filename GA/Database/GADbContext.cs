using GA.Entity.Student;
using Microsoft.EntityFrameworkCore;

namespace GA.Database
{
    public class GADbContext : DbContext
    {
        public GADbContext(DbContextOptions<GADbContext> options) : base(options)
        {
        }
        public DbSet<GA_STDCLASS> GA_STDCLASS { get; set; }
        public DbSet<GA_STDPREADMISSION> GA_STDPREADMISSION { get; set; }

        public DbSet<STD_UNQSERIES> STD_UNQSERIES { get; set; }

    }
}
