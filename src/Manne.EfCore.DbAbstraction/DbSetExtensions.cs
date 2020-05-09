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
        public static IReadableDbSet<TEntity> AsIReadableDbSet<TEntity>(this DbSet<TEntity> dbSet) where TEntity : class
         => new DbReadableSetWrapper<TEntity>(dbSet ?? throw new ArgumentNullException(nameof(dbSet)));
    }

    internal class DbReadableSetWrapper<TEntity> : IReadableDbSet<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public DbReadableSetWrapper(DbSet<TEntity> dbSet) => _dbSet = dbSet;

        public Type ElementType => ((IQueryable)_dbSet).ElementType;

        public Expression Expression => ((IQueryable) _dbSet).Expression;

        public IQueryProvider Provider => ((IQueryable) _dbSet).Provider;

        public IEnumerator<TEntity> GetEnumerator() => ((IEnumerable<TEntity>) _dbSet).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<TEntity>)_dbSet).GetEnumerator();

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
            ((IAsyncEnumerable<TEntity>) _dbSet).GetAsyncEnumerator(cancellationToken);
    }
}
