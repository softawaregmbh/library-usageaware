using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;

namespace UsageAware.ApplicationInsights
{
    public class UsageAwareLogger : IUsageAwareLogger
    {
        private readonly TelemetryClient client;

        public UsageAwareLogger()
        {
            this.client = UsageAware.GetTelemetryClient();
        }

        public Task TrackActionAsync(string area, string action, TimeSpan? duration = null)
        {            
            var properties = new Dictionary<string, string>()
            {
                ["action"] = action                
            };

            if (duration.HasValue)
            {
                properties.Add("duration", duration.ToString());
            }

            this.client.TrackEvent(area, properties);

            return Task.CompletedTask;
        }
    }
}
