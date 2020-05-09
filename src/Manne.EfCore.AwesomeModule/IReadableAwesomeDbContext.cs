using System.Linq;
using Manne.EfCore.DbAbstraction;

namespace Manne.EfCore.AwesomeModule
{
    public interface IReadableAwesomeDbContext : IReadableDbContext
    {
        IQueryable<Awesome> Awesomes { get; }

        IQueryable<Great> Greats { get; }
    }
}