using System.Threading;
using System.Threading.Tasks;
using Manne.EfCore.AwesomeModule.Models;
using Microsoft.EntityFrameworkCore;

namespace Manne.EfCore.AwesomeModule.Internals
{
    internal class AwesomeWriteableDbContext : IWriteableAwesomeDbContext
    {
        private readonly AwesomeEfContext _awesomeEfContext;

        public AwesomeWriteableDbContext(AwesomeEfContext awesomeEfContext)
        {
            _awesomeEfContext = awesomeEfContext;
        }

        public async ValueTask SaveChangesAsync(CancellationToken cancellationToken)
        {
            _ = await _awesomeEfContext.SaveChangesAsync(cancellationToken);
        }

        public void Add(Awesome entity)
        {
            _awesomeEfContext.Entry(entity).State = EntityState.Added;
            _awesomeEfContext.Awesome.Add(entity);
        }

        public void Add(Great entity)
        {
            _awesomeEfContext.Entry(entity).State = EntityState.Added;
            _awesomeEfContext.Great.Add(entity);
        }
    }
}