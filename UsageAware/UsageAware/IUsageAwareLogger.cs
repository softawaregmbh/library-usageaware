using System;
using System.Threading.Tasks;

namespace UsageAware
{
    public interface IUsageAwareLogger
    {
        Task TrackActionAsync(string area, string action, TimeSpan? duration = null);
    }
}
