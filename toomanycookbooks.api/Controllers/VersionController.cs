using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TooManyCookbooks.Api.Configuration;

namespace TooManyCookbooks.Api.Contollers
{
    [Route("/api/[controller]")]
    public class VersionController : ControllerBase
    {
        private readonly GlobalConfiguration _config;

        public VersionController(GlobalConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_config.Version);
        }
    }
}