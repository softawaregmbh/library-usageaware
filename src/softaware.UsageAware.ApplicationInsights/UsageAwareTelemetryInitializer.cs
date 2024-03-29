﻿using System;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace softaware.UsageAware.ApplicationInsights
{
    public class UsageAwareTelemetryInitializer : ITelemetryInitializer
    {
        private readonly Func<UsageAwareContext> contextProvider;

        public UsageAwareTelemetryInitializer(Func<UsageAwareContext> contextProvider)
        {
            this.contextProvider = contextProvider ?? throw new ArgumentNullException(nameof(contextProvider));
        }

        public void Initialize(ITelemetry telemetry)
        {
            var context = this.contextProvider();

            if (context.UserId != null)
            {
                telemetry.Context.User.AuthenticatedUserId = context.UserId;
            }

            if (context.TenantId != null)
            {
                telemetry.Context.User.AccountId = context.TenantId;
            }
        }
    }
}
