using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Text;

namespace softaware.UsageAware.ApplicationInsights
{
    class TelemetryInitializer : ITelemetryInitializer
    {
        private readonly Func<UsageAwareContext> contextProvider;

        public TelemetryInitializer(Func<UsageAwareContext> contextProvider)
        {
            this.contextProvider = contextProvider ?? throw new ArgumentNullException(nameof(contextProvider));
        }

        public void Initialize(ITelemetry telemetry)
        {
            var context = this.contextProvider();

            if (context.UserId != null)
            {
                telemetry.Context.User.Id = context.UserId;
            }

            if (context.TenantId != null)
            {
                telemetry.Context.User.AccountId = context.TenantId;
            }
        }
    }
}
