using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Config_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 从系统环境变量获取值 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> GetSysPath()
        {
            return Environment.GetEnvironmentVariable("Path");
        }
    }
}
