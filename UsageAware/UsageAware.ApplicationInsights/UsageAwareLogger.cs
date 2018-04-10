using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsageAware.ApplicationInsights;

namespace UsageAware.ApplicationInsights
{
    public class UsageAwareLogger : IUsageAwareLogger
    {
        private string instrumentationKey;

        public UsageAwareLogger(string instrumentationKey)
        {
            this.instrumentationKey = instrumentationKey;
        }

        public Task LoginAsync(string userId, string tenant = null)
        {
            throw new NotImplementedException();
        }

        public Task TrackActionAsync(string action, string detailedAction)
        {
            var tc = new TelemetryClient(new TelemetryConfiguration(instrumentationKey));
            
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
