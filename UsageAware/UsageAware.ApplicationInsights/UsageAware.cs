using System;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace UsageAware.ApplicationInsights
{
    public static class UsageAware
    {
        private static TelemetryConfiguration configuration;

        public static void Initialize(string instrumentationKey, Func<UsageAwareContext> contextProvider, bool addSessionAndUserDataToAI)
        {           
            if (configuration != null)
            {
                throw new InvalidOperationException("UsageAware is already initialized.");
            }

            if (addSessionAndUserDataToAI)
            {
                // add initializer for active configuration that is used for default Application Insights
                TelemetryConfiguration.Active.TelemetryInitializers.Add(new TelemetryInitializer(contextProvider));
            }

            // create a configuration to use for the UsageAware events
            configuration = new TelemetryConfiguration(instrumentationKey);
            configuration.TelemetryInitializers.Add(new TelemetryInitializer(contextProvider));
        }

        internal static TelemetryClient GetTelemetryClient()
        {
            if (configuration == null)
            {
                throw new InvalidOperationException("UsageAware is not initialized.");
            }
            
            return new TelemetryClient(configuration);
        }
    }
}
