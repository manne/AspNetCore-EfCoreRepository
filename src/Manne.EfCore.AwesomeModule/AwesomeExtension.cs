using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
        => serviceCollection.AddScoped<IAwesomeDbContext, AwesomeDbContext>();
    }
}
