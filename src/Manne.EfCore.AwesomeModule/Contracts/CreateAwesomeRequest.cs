using FluentValidation;

namespace Manne.EfCore.AwesomeModule.Contracts
{
    public sealed class CreateAwesomeRequest
    {
        public string Blub { get; set; }
        public string Bla { get; set; }

        public sealed class Validator : AbstractValidator<CreateAwesomeRequest>
        {
            public Validator()
            {
                RuleFor(r => r.Bla).NotEmpty();
                RuleFor(r => r.Blub).NotEmpty();
            }
        }
    }
}
