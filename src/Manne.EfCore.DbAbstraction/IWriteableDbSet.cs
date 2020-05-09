namespace Manne.EfCore.DbAbstraction
{
    public interface IWriteableDbSet<in TEntity> where TEntity : class
    {
        void Add(TEntity entity);
    }
}
