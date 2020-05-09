using Manne.EfCore.AwesomeModule.Models;
using Manne.EfCore.DbAbstraction;

namespace Manne.EfCore.AwesomeModule
{
    public interface IWriteableAwesomeDbContext : IWriteableDbContext, IWriteableDbSet<Awesome>, IWriteableDbSet<Great>
    {
    }
}