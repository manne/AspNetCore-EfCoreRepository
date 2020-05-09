using System.Threading;
using System.Threading.Tasks;
using Manne.EfCore.AwesomeModule.Contracts;
using Manne.EfCore.AwesomeModule.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Manne.EfCore.AwesomeModule.Handlers
{
    public sealed class GetSingleHandler : IRequestHandler<GetSingleQuery, Awesome>
    {
        private readonly IReadableAwesomeDbContext _readableDbContext;

        public GetSingleHandler(IReadableAwesomeDbContext readableDbContext)
        {
            _readableDbContext = readableDbContext;
        }

        public async Task<Awesome> Handle(GetSingleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _readableDbContext.Awesomes.FirstAsync(a => a.Id == request.Id, cancellationToken);
            return entity;
        }
    }
}
