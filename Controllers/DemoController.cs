using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Index()
        {
            _logger.LogTrace("Logging trace");
            _logger.LogDebug("Logging message from debug");
            _logger.LogInformation("Logging information");
            _logger.LogWarning("Logging trace");
            _logger.LogError("Logging error messsage");
            _logger.LogCritical("Logging critical message");
            
            return Ok();
        }
    }
}