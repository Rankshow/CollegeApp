using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IMyLogger _myLogger;
        public DemoController()
        {
            _myLogger = new LogToServerMermory();
        }
        [HttpGet]
        public ActionResult Index()
        {
            _myLogger.Log("Index method started");
            return Ok();
        }
    }
}