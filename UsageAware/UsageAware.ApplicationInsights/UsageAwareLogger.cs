using Microsoft.ApplicationInsights.Channel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsageAware.ApplicationInsights;

namespace UsageAware.ApplicationInsights
{
    public class UsageAwareLogger : IUsageAwareLogger
    {
        public Task LoginAsync(string userId, string tenant = null)
        {
            throw new NotImplementedException();
        }
    }
}
