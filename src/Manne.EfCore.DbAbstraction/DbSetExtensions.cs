using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Manne.EfCore.DbAbstraction
{
    public static class DbSetExtensions
    {
        public static IDbSet<TEntity> AsIDbSet<TEntity>(this DbSet<TEntity> dbSet) where TEntity : class
         => new DbSetWrapper<TEntity>(dbSet);
    }

    internal class DbSetWrapper<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public DbSetWrapper(DbSet<TEntity> dbSet) => _dbSet = dbSet;

        public Type ElementType => ((IQueryable)_dbSet).ElementType;

        public Expression Expression => ((IQueryable) _dbSet).Expression;

        public IQueryProvider Provider => ((IQueryable) _dbSet).Provider;

        public void Add(TEntity entity) => _dbSet.Add(entity);

        public void AddRange(params TEntity[] entities) => _dbSet.AddRange(entities);

        public IEnumerator<TEntity> GetEnumerator() => ((IEnumerable<TEntity>) _dbSet).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<TEntity>)_dbSet).GetEnumerator();

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
            ((IAsyncEnumerable<TEntity>) _dbSet).GetAsyncEnumerator(cancellationToken);
    }
}
