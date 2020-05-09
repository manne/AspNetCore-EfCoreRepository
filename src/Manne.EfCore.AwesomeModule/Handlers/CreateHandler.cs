using System.Threading;
using System.Threading.Tasks;
using Manne.EfCore.AwesomeModule.Contracts;
using Manne.EfCore.AwesomeModule.Models;
using MediatR;

namespace Manne.EfCore.AwesomeModule.Handlers
{
    internal sealed class CreateHandler : IRequestHandler<CreateAwesomeCommand, Awesome>
    {
        private readonly IWriteableAwesomeDbContext _writeableDbContext;

        public CreateHandler(IWriteableAwesomeDbContext writeableDbContext)
        {
            _writeableDbContext = writeableDbContext;
        }

        public async Task<Awesome> Handle(CreateAwesomeCommand request, CancellationToken cancellationToken)
        {
            var instanceToCreate = new Awesome
            {
                Bla = request.Bla,
                Blub = request.Blub
            };
            _writeableDbContext.Add(instanceToCreate);
            await _writeableDbContext.SaveChangesAsync(cancellationToken);
            return instanceToCreate;
        }
    }
}
