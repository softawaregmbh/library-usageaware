using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsageAware.ApplicationInsights
{
    public class UsageAwareLogger : IUsageAwareLogger
    {
        public Task TrackActionAsync(string action, string detailedAction)
        {
            var tc = new TelemetryClient(new TelemetryConfiguration(UsageAware.InstrumentationKey));
            
            tc.TrackEvent(
                action, 
                new Dictionary<string, string>()
                {
                    { "detailedAction", "created" }
                });

            return Task.CompletedTask;
        }
    }
}
