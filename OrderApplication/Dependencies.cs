using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderApplication.Handlers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Diamond.Application
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
           return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}