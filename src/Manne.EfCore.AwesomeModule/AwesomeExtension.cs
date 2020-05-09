using System;
using FluentValidation.AspNetCore;
using Manne.EfCore.AwesomeModule.Contracts;
using Manne.EfCore.AwesomeModule.Internals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using Sieve.Services;

namespace Manne.EfCore.AwesomeModule
{
    public static class AwesomeExtension
    {
        public static IServiceCollection AddAwesomeModuleDbContext(this IServiceCollection serviceCollection,
            Action<DbContextOptionsBuilder> optionsAction = null,
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
            ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
        => serviceCollection.AddDbContext<AwesomeEfContext>(optionsAction, contextLifetime, optionsLifetime);

        public static IServiceCollection AddAwesomeModule(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddControllers()
                .AddFluentValidation(configure => configure.RegisterValidatorsFromAssemblyContaining<IWriteableAwesomeDbContext>());
            return serviceCollection
                .AddScoped<IReadableAwesomeDbContext, AwesomeReadableDbContext>()
                .AddScoped<IWriteableAwesomeDbContext, AwesomeWriteableDbContext>()
                .AddScoped<ISieveProcessor<GetAllRequest, FilterTerm, SortTerm>, SieveProcessor<GetAllRequest, FilterTerm, SortTerm>>();
        }
    }
}
