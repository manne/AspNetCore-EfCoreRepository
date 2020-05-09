using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Manne.EfCore.AwesomeModule.Contracts;
using Manne.EfCore.AwesomeModule.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Manne.EfCore.AwesomeModule.Handlers
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, IImmutableList<Awesome>>
    {
        private readonly IReadableAwesomeDbContext _readableAwesomeDbContext;
        private readonly ISieveProcessor<GetAllQuery, FilterTerm, SortTerm> _sieveProcessor;

        public GetAllHandler(IReadableAwesomeDbContext readableAwesomeDbContext, ISieveProcessor<GetAllQuery, FilterTerm, SortTerm> sieveProcessor)
        {
            _readableAwesomeDbContext = readableAwesomeDbContext;
            _sieveProcessor = sieveProcessor;
        }

        public async Task<IImmutableList<Awesome>> Handle(GetAllQuery query, CancellationToken cancellationToken)
        {
            var queryable = _readableAwesomeDbContext.Awesomes;
            queryable = _sieveProcessor.Apply(query, queryable);
            var entities = await queryable.ToListAsync(cancellationToken);
            return entities.ToImmutableList();
        }
    }
}
