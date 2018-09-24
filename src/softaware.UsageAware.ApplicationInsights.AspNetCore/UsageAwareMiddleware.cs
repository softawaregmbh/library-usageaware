using System;
using Microsoft.Extensions.DependencyInjection;
using softaware.UsageAware;
using softaware.UsageAware.ApplicationInsights;

namespace Microsoft.AspNetCore.Builder
{
    public static class UsageAwareMiddleware
    {
        public static IServiceCollection AddUsageAware(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IUsageAwareLogger, UsageAwareLogger>();

            return services;
        }

        public static IApplicationBuilder UseUsageAware(this IApplicationBuilder app, Action<UsageAwareOptions> setupAction)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            var options = new UsageAwareOptions();

            setupAction(options);

            softaware.UsageAware.ApplicationInsights.UsageAware.Initialize(
                options.InstrumentationKey, 
                options.ContextProvider, 
                options.AddContextInformationToDefaultAIEvents);

            return app;
        }
    }
}
