using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cache_Redis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Index()
        {
            return "Redis分布式缓存 ";
        }
    }
}
