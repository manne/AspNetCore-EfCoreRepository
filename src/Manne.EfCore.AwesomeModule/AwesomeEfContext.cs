using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

    internal class AwesomeReadableDbContext : IReadableAwesomeDbContext
    {
        public AwesomeReadableDbContext(AwesomeEfContext awesomeEfContext)
            => (Awesomes, Greats) = (awesomeEfContext.Awesome.AsIReadableDbSet(), awesomeEfContext.Great.AsIReadableDbSet());

        public IQueryable<Awesome> Awesomes { get; }

        public IQueryable<Great> Greats { get; }
    }

    internal class AwesomeWriteableDbContext : IWriteableAwesomeDbContext
    {
        private readonly AwesomeEfContext _awesomeEfContext;

        public AwesomeWriteableDbContext(AwesomeEfContext awesomeEfContext)
        {
            _awesomeEfContext = awesomeEfContext;
        }

        public void AddAwesome(Awesome awesome)
        {
            _awesomeEfContext.Entry(awesome).State = EntityState.Added;
            _awesomeEfContext.Awesome.Add(awesome);
        }

        public async ValueTask SaveChangesAsync(CancellationToken cancellationToken)
        {
            _ = await _awesomeEfContext.SaveChangesAsync(cancellationToken);
        }
    }

    public interface IReadableAwesomeDbContext : IReadableDbContext
    {
        IQueryable<Awesome> Awesomes { get; }

        IQueryable<Great> Greats { get; }
    }

    public interface IWriteableAwesomeDbContext : IWriteableDbContext
    {
        void AddAwesome(Awesome awesome);
    }
}
