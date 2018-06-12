namespace UsageAware
{
    public class UsageAwareContext
    {
        public UsageAwareContext(string userId = null, string tenantId = null)
        {
            this.UserId = userId;
            this.TenantId = tenantId;
        }

        public string UserId { get; private set; }
        public string TenantId { get; private set; }
    }
}
