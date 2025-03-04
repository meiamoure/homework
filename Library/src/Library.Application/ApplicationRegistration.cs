﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;
public static class ApplicationRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
