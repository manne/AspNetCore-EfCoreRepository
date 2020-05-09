using Manne.EfCore.DbAbstraction;
using Microsoft.EntityFrameworkCore;

namespace Manne.EfCore.AwesomeModule
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

    internal class AwesomeDbContext : IAwesomeDbContext
    {
        public AwesomeDbContext(AwesomeEfContext awesomeEfContext)
        {
            Awesomes = awesomeEfContext.Awesome.AsIDbSet();
            Greats = awesomeEfContext.Great.AsIDbSet();
        }
        public IDbSet<Awesome> Awesomes { get; }
        public IDbSet<Great> Greats { get; }
    }

    public interface IAwesomeDbContext : IDbContext
    {
        IDbSet<Awesome> Awesomes { get; }

        IDbSet<Great> Greats { get; }
    }
}
