using System.Threading.Tasks;

namespace UsageAware
{
    public interface IUsageAwareLogger
    {
        Task TrackActionAsync(string action, string detailedAction);
    }
}
