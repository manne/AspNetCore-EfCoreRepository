using Manne.EfCore.AwesomeModule.Models;
using Microsoft.EntityFrameworkCore;

namespace Manne.EfCore.AwesomeModule.Internals
{
    internal class AwesomeEfContext : DbContext
    {
        public AwesomeEfContext()
        {
        }

        public AwesomeEfContext(DbContextOptions<AwesomeEfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Awesome> Awesome { get; set; }

        public virtual DbSet<Great> Great { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AwesomeConfiguration());
            modelBuilder.ApplyConfiguration(new GreatConfiguration());
        }
    }
}
