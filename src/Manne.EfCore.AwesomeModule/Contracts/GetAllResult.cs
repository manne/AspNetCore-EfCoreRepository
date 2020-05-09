using System;
using System.Collections.Immutable;
using Manne.EfCore.AwesomeModule.Models;

namespace Manne.EfCore.AwesomeModule.Contracts
{
    public sealed class GetAllResult
    {
        public GetAllResult(IImmutableList<Awesome> awesomes)
        {
            Awesomes = awesomes ?? throw new ArgumentNullException(nameof(awesomes));
        }

        public IImmutableList<Awesome> Awesomes { get; }
    }
}