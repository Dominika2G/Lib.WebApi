using System;
using System.Collections.Generic;
using System.Reflection;
using FluentValidation.AspNetCore;
using Lib.Modules.Auth.Application;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.WebApi
{
    public static class Extensions
    {
        public static IServiceCollection AddWebApiInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
        {
            var assembliesApplication = new List<Assembly>
            {
                AppDomain.CurrentDomain.Load("Lib.Modules.Auth.Application"),
            };

            services.AddSwaggerDocumentation();
            services.AddHttpContextAccessor();
            services.AddCorsPolicy(configuration);
            services.AddMediatR(assembliesApplication.ToArray());
            services.AddControllers().AddFluentValidation(s => s.RegisterValidatorsFromAssemblies(assembliesApplication));

            return services;
        }

        public static IApplicationBuilder UseWebApiInfrastructure(this IApplicationBuilder app)
        {
            app.UseSwaggerDocumentation();
            app.UseCorsPolicy();
            app.UseAuthentication();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            return app;
        }


        private static void AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedHosts = configuration.GetSection("FrontendClientUrl").Value;

            services.AddCors(options =>
            {
                options.AddPolicy("FrontendClient", builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(allowedHosts);
                });
            });
        }

        private static void UseCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors("FrontendClient");
        }
    }
}
