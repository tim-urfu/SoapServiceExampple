using Microsoft.AspNetCore.Mvc;

namespace SoapServiceExampple.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(1, 5).Select(index => index).ToArray();
        }
    }
}
