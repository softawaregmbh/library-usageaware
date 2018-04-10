using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UsageAware
{
    public interface IUsageAwareLogger
    {
        Task LoginAsync(string userId, string tenant = null);
    }
}
