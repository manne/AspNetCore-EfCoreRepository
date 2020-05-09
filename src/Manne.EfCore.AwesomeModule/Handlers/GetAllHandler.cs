using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Manne.EfCore.AwesomeModule.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Manne.EfCore.AwesomeModule.Handlers
{
    public class GetAllHandler : IRequestHandler<GetAllRequest, GetAllResult>
    {
        private readonly IReadableAwesomeDbContext _readableAwesomeDbContext;
        private readonly ISieveProcessor<GetAllRequest, FilterTerm, SortTerm> _sieveProcessor;

        public GetAllHandler(IReadableAwesomeDbContext readableAwesomeDbContext, ISieveProcessor<GetAllRequest, FilterTerm, SortTerm> sieveProcessor)
        {
            _readableAwesomeDbContext = readableAwesomeDbContext;
            _sieveProcessor = sieveProcessor;
        }

        public async Task<GetAllResult> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var queryable = _readableAwesomeDbContext.Awesomes;
            queryable = _sieveProcessor.Apply(request, queryable);
            var entities = await queryable.ToListAsync(cancellationToken);
            return new GetAllResult(entities.ToImmutableList());
        }
    }
}
