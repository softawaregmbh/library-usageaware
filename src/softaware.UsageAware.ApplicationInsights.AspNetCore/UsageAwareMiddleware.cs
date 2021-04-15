using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;
using softaware.UsageAware;
using softaware.UsageAware.ApplicationInsights;

namespace Microsoft.AspNetCore.Builder
{
    public static class UsageAwareMiddleware
    {
        public static IServiceCollection AddUsageAware(this IServiceCollection services, Func<UsageAwareContext> contextProvider)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<ITelemetryInitializer>(new UsageAwareTelemetryInitializer(contextProvider));
            services.AddScoped<IUsageAwareLogger, UsageAwareLogger>();

            return services;
        }

        public static IServiceCollection AddUsageAware(this IServiceCollection services, Func<IServiceProvider, UsageAwareContext> contextProvider)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<ITelemetryInitializer>(s => new UsageAwareTelemetryInitializer(() => contextProvider(s)));
            services.AddScoped<IUsageAwareLogger, UsageAwareLogger>();

            return services;
        }
    }
}
