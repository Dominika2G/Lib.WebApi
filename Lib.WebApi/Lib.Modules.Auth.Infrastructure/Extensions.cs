using Lib.Modules.Auth.Domain.Interfaces;
using Lib.Modules.Auth.Infrastructure.Repositories;
using Lib.Shared.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lib.Modules.Auth.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddDbContext<IDatabaseContext, DatabaseContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserViewRepository, UserViewRepository>();
            return services;
        }
    }
}
