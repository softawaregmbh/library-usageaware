using System;

namespace UsageAware.ApplicationInsights
{
    public class UsageAwareOptions
    {
        public string InstrumentationKey { get; set; }
        public Func<UsageAwareContext> ContextProvider { get; set; }
        public bool AddContextInformationToDefaultAIEvents { get; set; } = true;
    }
}