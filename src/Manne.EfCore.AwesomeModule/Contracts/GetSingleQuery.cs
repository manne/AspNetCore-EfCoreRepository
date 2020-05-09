using Manne.EfCore.AwesomeModule.Models;
using MediatR;

namespace Manne.EfCore.AwesomeModule.Contracts
{
    public sealed class GetSingleQuery : IRequest<Awesome>
    {
        public int Id { get; set; }
    }
}
