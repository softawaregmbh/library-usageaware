using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using softaware.UsageAware.ApplicationInsights;
using softaware.UsageAware.UI.DemoClient.ViewModels;
using System.Windows;

namespace softaware.UsageAware.UI.DemoClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // TODO: read from config, use dependency injection
            TelemetryConfiguration.Active.InstrumentationKey = "94287a08-a0b8-483d-9cf5-2c18cb1f88cf";
            TelemetryConfiguration.Active.TelemetryInitializers.Add(new UsageAwareTelemetryInitializer(() => new UsageAwareContext("demo-user", "demo-tenant")));

            this.DataContext = new MainViewModel(new UsageAwareLogger());
        }
    }
}
