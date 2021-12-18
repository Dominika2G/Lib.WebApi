using Lib.Modules.Book.Domain.Interfaces;
using Lib.Modules.Book.Infrastructure.Repositories;
using Lib.Shared.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.Modules.Book.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddBookInfrastructure(this IServiceCollection services)
    {

        services.AddDbContext<IDatabaseContext, DatabaseContext>();
        services.AddScoped<IBookRepository, BookRepository>();
        return services;
    }
}

