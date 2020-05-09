using System.Collections.Generic;
using System.Linq;

namespace Manne.EfCore.DbAbstraction
{
    public interface IReadableDbSet<out TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity> where TEntity : class
    {
    }
}
