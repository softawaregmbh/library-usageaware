using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UsageAware.UI.DemoClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var sessionId = Guid.NewGuid().ToString();
            ApplicationInsights.UsageAware.Initialize("94287a08-a0b8-483d-9cf5-2c18cb1f88cf", () => new UsageAwareContext(sessionId));
        }
    }
}
