using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsageAware.ApplicationInsights
{
    public static class UsageAware
    {
        private static bool isInitialized;

        public static void Initialize(Func<UsageAwareContext> contextProvider)
        {           
            if (isInitialized)
            {
                throw new InvalidOperationException("UsageAware is already initialized.");
            }

            TelemetryConfiguration.Active.TelemetryInitializers.Add(new TelemetryInitializer(contextProvider));

            isInitialized = true;
        }
    }
}
