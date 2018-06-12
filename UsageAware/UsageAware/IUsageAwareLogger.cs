using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsageAware
{
    public interface IUsageAwareLogger
    {
        Task TrackActionAsync(string area, string action, IEnumerable<KeyValuePair<string, string>> additionalProperties = null);
    }
}
