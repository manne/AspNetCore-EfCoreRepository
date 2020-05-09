using System.Collections.Generic;
using System.Linq;

namespace Manne.EfCore.DbAbstraction
{
    public interface IDbSet<TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(params TEntity[] entities);
    }
}
