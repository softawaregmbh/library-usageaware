using System;

namespace UsageAware
{
    public class UsageAwareContext
    {
        public UsageAwareContext(string sessionId, string userId = null, string tenantId = null)
        {
            this.SessionId = sessionId ?? throw new ArgumentNullException(nameof(sessionId));
            this.UserId = userId;
            this.TenantId = tenantId;
        }

        public string SessionId { get; private set; }
        public string UserId { get; private set; }
        public string TenantId { get; private set; }
    }
}
