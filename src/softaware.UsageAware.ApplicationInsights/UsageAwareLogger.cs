using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;

namespace softaware.UsageAware.ApplicationInsights
{
    public class UsageAwareLogger : IUsageAwareLogger
    {
        private readonly TelemetryClient client;

        public UsageAwareLogger(TelemetryClient client)
        {
            this.client = client;
        }

        public UsageAwareLogger(TelemetryClient client, UsageAwareContext context)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.UserId != null)
            {
                this.client.Context.User.Id = context.UserId;
            }

            if (context.TenantId != null)
            {
                this.client.Context.User.AccountId = context.TenantId;
            }
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
