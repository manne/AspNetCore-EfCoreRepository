using FluentValidation;
using Manne.EfCore.AwesomeModule.Models;
using MediatR;

namespace Manne.EfCore.AwesomeModule.Contracts
{
    public sealed class CreateAwesomeCommand : IRequest<Awesome>
    {
        public string Blub { get; set; }
        public string Bla { get; set; }

        public sealed class Validator : AbstractValidator<CreateAwesomeCommand>
        {
            public Validator()
            {
                RuleFor(r => r.Bla).NotEmpty();
                RuleFor(r => r.Blub).NotEmpty();
            }
        }
    }
}
