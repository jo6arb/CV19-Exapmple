﻿using CV19.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CV19.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            services.AddTransient<IAsyngDataService, AsyncDataService>();

            return services;
        }
    }
}
