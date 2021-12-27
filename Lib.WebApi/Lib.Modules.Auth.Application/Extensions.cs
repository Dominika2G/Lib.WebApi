using Lib.Modules.Auth.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lib.Modules.Auth.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAuthModule(this IServiceCollection services)
        {
            services.AddInfrastructure();
            return services;
        }
    }
}
