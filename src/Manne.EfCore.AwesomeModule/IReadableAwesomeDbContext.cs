using System.Linq;
using Manne.EfCore.AwesomeModule.Models;
using Manne.EfCore.DbAbstraction;

namespace Manne.EfCore.AwesomeModule
{
    public interface IReadableAwesomeDbContext : IReadableDbContext
    {
        IQueryable<Awesome> Awesomes { get; }

        IQueryable<Great> Greats { get; }
    }
}