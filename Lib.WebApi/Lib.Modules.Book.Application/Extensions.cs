using Lib.Modules.Book.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.Modules.Book.Application;

public static class Extensions
{
    public static IServiceCollection AddBookModule(this IServiceCollection services)
    {
        services.AddBookInfrastructure();
        return services;
    }
}
