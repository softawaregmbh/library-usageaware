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

        public Task TrackActionAsync(string area, string action, IEnumerable<KeyValuePair<string, string>> additionalProperties = null)
        {
            var properties = new Dictionary<string, string>();

            if (additionalProperties != null)
            {
                foreach (var additionalProperty in additionalProperties)
                {
                    properties.Add(additionalProperty.Key, additionalProperty.Value);
                };
            }

            properties["area"] = area;

            this.client.TrackEvent(action, properties);

            return Task.CompletedTask;
        }
    }
}
