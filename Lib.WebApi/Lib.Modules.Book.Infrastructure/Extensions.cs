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
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBorrowRepository, BorrowRepository>();
        services.AddScoped<IBookViewRepository, BookViewRepository>();  
        services.AddScoped<IBorrowViewRepository, BorrowViewRepository>();
        services.AddScoped<ICommentBookRepository, CommentBookRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        return services;
    }
}

