using Manne.EfCore.AwesomeModule.Models;
using Manne.EfCore.DbAbstraction;

namespace Manne.EfCore.AwesomeModule
{
    internal interface IWriteableAwesomeDbContext : IWriteableDbContext, IWriteableDbSet<Awesome>, IWriteableDbSet<Great>
    {
    }
}