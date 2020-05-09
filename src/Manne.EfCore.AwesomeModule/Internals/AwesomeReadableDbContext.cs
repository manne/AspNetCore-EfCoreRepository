using System.Linq;
using Manne.EfCore.DbAbstraction;

namespace Manne.EfCore.AwesomeModule.Internals
{
    internal class AwesomeReadableDbContext : IReadableAwesomeDbContext
    {
        public AwesomeReadableDbContext(AwesomeEfContext awesomeEfContext)
            => (Awesomes, Greats) = (awesomeEfContext.Awesome.AsIReadableDbSet(), awesomeEfContext.Great.AsIReadableDbSet());

        public IQueryable<Awesome> Awesomes { get; }

        public IQueryable<Great> Greats { get; }
    }
}