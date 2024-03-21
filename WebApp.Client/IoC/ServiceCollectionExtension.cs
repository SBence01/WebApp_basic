﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Client.Models;

namespace WebApp.Client.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddWebAppClientService(this IServiceCollection services,
            Action<ApiClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new WebAppClientService(options);
            });
        }
    }
}
