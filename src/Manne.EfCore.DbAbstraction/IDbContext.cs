using System.Threading;
using System.Threading.Tasks;

namespace Manne.EfCore.DbAbstraction
{
    public interface IReadableDbContext
    {
    }

    public interface IWriteableDbContext
    {
        ValueTask SaveChangesAsync(CancellationToken cancellationToken);
    }
}
