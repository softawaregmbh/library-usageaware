using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsageAware.ApplicationInsights
{
    public static class UsageAware
    {
        private static bool isInitialized = false;
        private static string instrumentationKey;

        public static string InstrumentationKey => isInitialized ? instrumentationKey : throw new InvalidOperationException("UsageAware is not initialized.");


        public static void Initialize(string instrumentationKey, Func<UsageAwareContext> contextProvider)
        {           
            if (isInitialized)
            {
                throw new InvalidOperationException("UsageAware is already initialized.");
            }

            UsageAware.instrumentationKey = instrumentationKey ?? throw new ArgumentNullException(nameof(instrumentationKey));
            TelemetryConfiguration.Active.TelemetryInitializers.Add(new TelemetryInitializer(contextProvider));

            isInitialized = true;
        }
    }
}
