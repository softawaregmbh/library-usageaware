using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace softaware.UsageAware.UI.WebApp
{
    public class EnvironmentTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.GlobalProperties["tag"] = "dev";
        }
    }
}
