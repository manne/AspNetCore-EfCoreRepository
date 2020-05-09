using Microsoft.EntityFrameworkCore;

namespace WebApplication
{
    public class AwesomeContext : DbContext
    {
        public AwesomeContext()
        {
        }

        public AwesomeContext(DbContextOptions<AwesomeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Awesome> Awesome { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AwesomeConfiguration());
        }
    }
}
