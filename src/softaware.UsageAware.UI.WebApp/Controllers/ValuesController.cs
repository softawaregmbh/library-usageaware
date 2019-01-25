using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace softaware.UsageAware.UI.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUsageAwareLogger usageAwareLogger;

        public ValuesController(IUsageAwareLogger usageAwareLogger)
        {
            this.usageAwareLogger = usageAwareLogger ?? throw new ArgumentNullException(nameof(usageAwareLogger));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            this.usageAwareLogger.TrackActionAsync("Values", "Get", new Dictionary<string, string>() { { "key", "value" } });
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("Exception")]
        public ActionResult<IEnumerable<string>> Exception()
        {
            throw new Exception("Test");
        }
    }
}
